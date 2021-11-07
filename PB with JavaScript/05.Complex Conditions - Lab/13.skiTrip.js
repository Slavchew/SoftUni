function skiTrip(input) {

    let days = Number(input[0]);
    let roomType = input[1];
    let grade = input[2];

    let sum = 0;
    if (roomType === "room for one person") {
        sum = (days - 1) * 18;
        if (grade == "positive") {
            sum *= 1.25;
        } else if (grade == "negative") {
            sum *= 0.90;
        }
    } else if (roomType === "apartment") {
        sum = (days - 1) * 25;
        if (days < 10) {
            sum *= 0.70;
        } else if (days >= 10 && days <= 15) {
            sum *= 0.65;
        } else {
            sum *= 0.50;
        }

        if (grade == "positive") {
            sum *= 1.25;
        } else if (grade == "negative") {
            sum *= 0.90;
        }
    } else if (roomType === "president apartment") {
        sum = (days - 1) * 35;
        if (days < 10) {
            sum *= 0.90;
        } else if (days >= 10 && days <= 15) {
            sum *= 0.85;
        } else {
            sum *= 0.80;
        }

        if (grade == "positive") {
            sum *= 1.25;
        } else if (grade == "negative") {
            sum *= 0.90;
        }
    }

    console.log(sum.toFixed(2));
}
skiTrip(["30",
"president apartment",
"negative"])
