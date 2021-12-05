class Movie {
    constructor(movieName, ticketPrice) {
        this.movieName = movieName;
        this.ticketPrice = Number(ticketPrice);
        this.screenings = [];
        this._revenue = 0;
        this._ticketsSold = 0;
    }

    newScreening(date, hall, description) {
        if (this.screenings.some(x => x.date == date && x.hall == hall)) {
            throw new Error(`Sorry, ${hall} hall is not available on ${date}`)
        }

        this.screenings.push({ date, hall, description });

        return `New screening of ${this.movieName} is added.`;
    }

    endScreening(date, hall, soldTickets) {
        const screening = this.screenings.find(x => x.date == date && x.hall == hall);
        if (screening == undefined) {
            throw new Error(`Sorry, there is no such screening for ${this.movieName} movie.`)
        }

        const index = this.screenings.indexOf(screening);
        this.screenings.splice(index, 1);

        const profit = this.ticketPrice * soldTickets;

        this._revenue += profit;
        this._ticketsSold += soldTickets;

        return `${this.movieName} movie screening on ${date} in ${hall} hall has ended. Screening profit: ${profit}`
    }

    toString() {
        const result = [
            `${this.movieName} full information:`,
            `Total profit: ${Number(this._revenue).toFixed(0)}$`,
            `Sold Tickets: ${Number(this._ticketsSold).toFixed(0)}`
        ];
        if (this.screenings.length > 0) {
            result.push("Remaining film screenings:");

            this.screenings.sort((a, b) => {
                return a.hall.localeCompare(b.hall);
            });

            for (const screening of this.screenings) {
                result.push(`${screening.hall} - ${screening.date} - ${screening.description}`);
            }
        } else {
            result.push("No more screenings!");
        }

        return result.join('\n');
    }
}

let m = new Movie('Wonder Woman 1984', '10.00');
console.log(m.newScreening('October 2, 2020', 'IMAX 3D', `3D`));
console.log(m.newScreening('October 3, 2020', 'Main', `regular`));
console.log(m.newScreening('October 4, 2020', 'IMAX 3D', `3D`));
console.log(m.endScreening('October 2, 2020', 'IMAX 3D', 150));
console.log(m.endScreening('October 3, 2020', 'Main', 78));
console.log(m.toString());

m.newScreening('October 4, 2020', '235', `regular`);
m.newScreening('October 5, 2020', 'Main', `regular`);
m.newScreening('October 3, 2020', '235', `regular`);
m.newScreening('October 4, 2020', 'Main', `regular`);
console.log(m.toString());
