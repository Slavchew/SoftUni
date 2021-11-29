function solve(arr, criteria) {
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    const tickets = [];
    for (const item of arr) {
        let [destination, price, status] = item.split('|');

        tickets.push(new Ticket(destination, Number(price), status));
    }

    if (criteria === 'price') {
        tickets.sort((a, b) => {
            return a.price - b.price;
        });
    } else if (criteria === 'destination') {
        tickets.sort((a, b) => {
            return a.destination.localeCompare(b.destination);
        });
    } else {
        tickets.sort((a, b) => {
            return a.status.localeCompare(b.status);
        });
    }

    return tickets;

}

console.log(solve(
    [
        'Philadelphia|94.20|available',
        'New York City|95.99|available',
        'New York City|95.99|sold',
        'Boston|126.20|departed'
    ],
    'destination'
));