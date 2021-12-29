function birthdayParty(input) {
    let roomPrice = Number(input[0]);

    let cake = roomPrice * 0.20;
    let beverages = cake * 0.55;
    let animator = roomPrice / 3;

    let sum = roomPrice + cake + beverages + animator;
    console.log(sum);
}
birthdayParty(["2250"])