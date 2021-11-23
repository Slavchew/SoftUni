function solution() {
    const recipes = {
        apple: { carbohydrate: 1, flavour: 2 },
        lemonade: { carbohydrate: 10, flavour: 20 },
        burger: { carbohydrate: 5, fat: 7, flavour: 3 },
        eggs: { protein: 5, fat: 1, flavour: 1 },
        turkey: { protein: 10, carbohydrate: 10, fat: 10, flavour: 10 }
    };

    const storage = {
        carbohydrate: 0,
        flavour: 0,
        fat: 0,
        protein: 0
    };

    function restock(microelement, quantity) {
        storage[microelement] += quantity;

        return 'Success';
    }

    function prepare(recipe, quantity) {
        const remainingStorage = {};

        for (const element in recipes[recipe]) {
            const remaining = storage[element] - recipes[recipe][element] * quantity;
            if (remaining < 0) {
                return `Error: not enough ${element} in stock`;
            } else {
                remainingStorage[element] = remaining;
            }
        }
        Object.assign(storage, remainingStorage);

        return 'Success';
    }

    function report() {
        return `protein=${storage['protein']} carbohydrate=${storage['carbohydrate']} fat=${storage['fat']} flavour=${storage['flavour']}`;
    }

    function control(input) {
        let [command, item, quantity] = input.split(' ');

        quantity = Number(quantity);

        if (command === 'restock') {
            return restock(item, quantity);
        } else if (command === 'prepare') {
            return prepare(item, quantity);
        } else if (command === 'report') {
            return report();
        }
    }

    return control;
}

let manager = solution();
console.log(manager("prepare turkey 1"));
console.log(manager("restock protein 10"));
console.log(manager("prepare turkey 1"));
console.log(manager("restock carbohydrate 10"));
console.log(manager("prepare turkey 1"));
console.log(manager("restock fat 10"));
console.log(manager("prepare turkey 1"));
console.log(manager("restock flavour 10"));
console.log(manager("prepare turkey 1"));
console.log(manager("report"));
