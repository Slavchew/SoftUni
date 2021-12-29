function fishingBoat(input) {
    
    let budget = Number(input[0]);
    let season = input[1];
    let fisherCount = Number(input[2]);

    let rentPrice = 0;

    if (season === "Spring") {
        rentPrice = 3000.00;
    } else if (season === "Summer" || season === "Autumn") {
        rentPrice = 4200.00;

    } else if (season === "Winter") {
        rentPrice = 2600.00;
    }

    if (fisherCount <= 6) {
        rentPrice *= 0.90;
    } else if (fisherCount >= 7 && fisherCount <= 11) {
        rentPrice *= 0.85;
    } else if (fisherCount >= 12) {
        rentPrice *= 0.75;
    }

    if (fisherCount % 2 == 0 && season !== "Autumn") {
        rentPrice *= 0.95;
    }

    if (budget >= rentPrice) {
        console.log(`Yes! You have ${(budget - rentPrice).toFixed(2)} leva left.`);
    } else {
        console.log(`Not enough money! You need ${(rentPrice - budget).toFixed(2)} leva.`);
    }
    
}
fishingBoat(["2000",
"Winter",
"13"])