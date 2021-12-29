function toyShop(input) {
    let tripPrice = Number(input[0]);
    let puzzleCount = Number(input[1]);
    let dollCount = Number(input[2]);
    let teddyBearCount = Number(input[3]);
    let minionsCount = Number(input[4]);
    let trucksCount = Number(input[5]);

    let sum = (puzzleCount * 2.60) + (dollCount * 3) 
    + (teddyBearCount * 4.10) + (minionsCount * 8.20) + (trucksCount * 2);

    let toysCount = puzzleCount + dollCount + teddyBearCount + minionsCount + trucksCount;

    // Discount
    if (toysCount >= 50) {
        sum *= 0.75;
    }

    // Taxes
    sum *= 0.90;
    

    if (sum >= tripPrice) {
        let sumLeft = sum - tripPrice;
        console.log(`Yes! ${sumLeft.toFixed(2)} lv left.`);
    } else {
        let moneyNeeded = tripPrice - sum;
        console.log(`Not enough money! ${moneyNeeded.toFixed(2)} lv needed.`);
    }
}
toyShop(["40.8", "20", "25", "30", "50", "10"])