function solve(arr) {

    let juices = new Map();
    let bottles = new Map();

    for (const item of arr) {
        let [name, qty] = item.split(' => ');
        qty = Number(qty);
        if (!juices.has(name)) {
            juices.set(name, qty);
        } else {
            qty += juices.get(name);
            juices.set(name, qty);
        }

        if (qty >= 1000) {
            let numberOfBottles = Math.floor(qty / 1000);
            bottles.set(name, numberOfBottles);
        }
    }

    for (const [key, value] of bottles) {
        console.log(`${key} => ${value}`);
    }
}

solve(
    [
        'Kiwi => 234',
        'Pear => 2345',
        'Watermelon => 3456',
        'Kiwi => 4567',
        'Pear => 5678',
        'Watermelon => 6789'
    ]

)