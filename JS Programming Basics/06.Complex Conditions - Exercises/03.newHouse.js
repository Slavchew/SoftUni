function newHouse(input) {
    
    let flowerType = input[0];
    let flowerCount = Number(input[1]);
    let budget = Number(input[2]);

    let flowerPrice = 0;
    if (flowerType === "Roses") {
        flowerPrice = 5.00;
        if (flowerCount > 80) {
            flowerPrice *= 0.9;
        }
    } else if (flowerType === "Dahlias") {
        flowerPrice = 3.80;
        if (flowerCount > 90) {
            flowerPrice *= 0.85;
        }
    } else if (flowerType === "Tulips") {
        flowerPrice = 2.80;
        if (flowerCount > 80) {
            flowerPrice *= 0.85;
        }
    } else if (flowerType === "Narcissus") {
        flowerPrice = 3.00;
        if (flowerCount < 120) {
            flowerPrice *= 1.15;
        }
    } else if (flowerType === "Gladiolus") {
        flowerPrice = 2.50;
        if (flowerCount < 80) {
            flowerPrice *= 1.20;
        }
    }

    let sum = flowerPrice * flowerCount;

    if (sum <= budget) {
        console.log(`Hey, you have a great garden with ${flowerCount} ${flowerType} and ${(budget - sum).toFixed(2)} leva left.`);
    } else {
        console.log(`Not enough money, you need ${(sum - budget).toFixed(2)} leva more.`);
    }
}
newHouse(["Narcissus",
"119",
"360"])