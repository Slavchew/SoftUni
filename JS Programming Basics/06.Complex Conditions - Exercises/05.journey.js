function journey(input) {
    
    let budget = Number(input[0]);
    let season = input[1];

    let place = "";
    let journeyType = "";
    if (budget <= 100) {
        place = "Bulgaria";
        if (season === "summer") {
            journeyType = "Camp"
            budget *= 0.30;
        } else if (season === "winter") {
            journeyType = "Hotel"
            budget *= 0.70;
        }
    } else if (budget <= 1000) {
        place = "Balkans";
        if (season === "summer") {
            journeyType = "Camp"
            budget *= 0.40;
        } else if (season === "winter") {
            journeyType = "Hotel"
            budget *= 0.80;
        }
    } else if (budget > 1000) {
        place = "Europe";
        journeyType = "Hotel";
        budget *= 0.9;
    }

    console.log(`Somewhere in ${place}`);
    console.log(`${journeyType} - ${budget.toFixed(2)}`);
}
journey(["678.53", "winter"])