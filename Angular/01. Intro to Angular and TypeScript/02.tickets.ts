class Destination {
    public destination: string;
    public price: number;
    public status: string;
    constructor(destination, price, status) {
        this.destination = destination;
        this.price = price;
        this.status = status;
    }
}

function tickets(array: string[], criteria: string) {
    const destination = array
        .map(x => x.split('|'))
        .map(([destination, price, status]) => new Destination(destination, price, status))
        .sort((a, b) => a[criteria].localeCompare(b[criteria]));
    
    return destination;
}

console.log(tickets([
    'Philadelphia|94.20|available',
     'New York City|95.99|available',
     'New York City|95.99|sold',
     'Boston|126.20|departed'
    ],
    'destination'
));

console.log("-------------------------");
console.log(tickets([
    'Philadelphia|94.20|available',
     'New York City|95.99|available',
     'New York City|95.99|sold',
     'Boston|126.20|departed'
    ],
    'status'
));