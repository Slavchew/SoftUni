function solve(arr) {
    const garage = new Map();

    for (const arg of arr) {
        let [brand, model, qty] = arg.split(' | ');
        qty = Number(qty);

        
        if (!garage.has(brand)) {
            let firstModel = new Map()
            garage.set(brand, firstModel.set(model, qty));
        } else {
            let brandModels = garage.get(brand);
            if (!brandModels.has(model)) {
                brandModels.set(model, qty);
            } else {
                const oldQty = brandModels.get(model);
                brandModels.set(model, qty + oldQty);
            }
        }
    }

    for (const [brand, model] of garage.entries()) {
        console.log(brand);
        for (const [modelName, qty] of model.entries()) {
            console.log(`###${modelName} -> ${qty}`);
        }
    }
}

solve(
    [
        'Audi | Q7 | 1000',
        'Audi | Q6 | 100',
        'BMW | X5 | 1000',
        'BMW | X6 | 100',
        'Citroen | C4 | 123',
        'Volga | GAZ-24 | 1000000',
        'Lada | Niva | 1000000',
        'Lada | Jigula | 1000000',
        'Citroen | C4 | 22',
        'Citroen | C5 | 10'
    ]
)