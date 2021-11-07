function vacationBooksList(input) {
    let bookPages = Number(input[0]);
    let pagesPerHour = Number(input[1]);
    let days = Number(input[2]);

    let hoursToReadBook = bookPages / pagesPerHour;
    let hoursPerDay = hoursToReadBook / days;

    console.log(hoursPerDay);
}
vacationBooksList(["212", "20", "2"])
