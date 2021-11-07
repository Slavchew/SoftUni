function calcPrice(fruit, weight, priceInKg) {
    
    let kg = Number(weight) / 1000;
    let sum = kg * Number(priceInKg);

    console.log(`I need $${sum.toFixed(2)} to buy ${kg.toFixed(2)} kilograms ${fruit}.`);
}

calcPrice('orange', 2500, 1.80)