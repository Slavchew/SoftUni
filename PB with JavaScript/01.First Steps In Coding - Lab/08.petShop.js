function petShop(input) {
    let dogs = Number(input[0]);
    let dogsFoodPrice = dogs * 2.50;
    let otherAnimals = Number(input[1]);
    let otherFoodPrice = otherAnimals * 4.00;

    let sum = dogsFoodPrice + otherFoodPrice;
    console.log(`${sum.toFixed(2)} lv.`);
}
petShop(["5", "4"])