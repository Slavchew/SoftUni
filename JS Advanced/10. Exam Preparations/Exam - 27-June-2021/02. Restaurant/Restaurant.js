class Restaurant {
    constructor(budget) {
        this.budgetMoney = budget;
        this.menu = {};
        this.stockProducts = {};
        this.history = [];
    }

    loadProducts(products) {
        // this.history = []; - Maybe a good practice
        for (const item of products) {
            let [name, qty, price] = item.split(' ');

            qty = Number(qty);
            price = Number(price);

            if (price <= this.budgetMoney) {

                if (!this.stockProducts.hasOwnProperty(name)) {
                    this.stockProducts[name] = qty;
                } else {
                    this.stockProducts[name] += qty;
                }

                this.budgetMoney -= price;

                this.history.push(`Successfully loaded ${qty} ${name}`);
            } else {
                this.history.push(`There was not enough money to load ${qty} ${name}`);
            }
        }

        return this.history.join('\n');
    }

    addToMenu(meal, products, price) {
        if (!this.menu.hasOwnProperty(meal)) {
            this.menu[meal] = {
                products: {},
                price
            };

            for (const item of products) {
                let [name, qty] = item.split(' ');

                qty = Number(qty);

                this.menu[meal].products[name] = qty;
            }

            if (Object.keys(this.menu).length == 1) {
                return `Great idea! Now with the ${meal} we have 1 meal in the menu, other ideas?`
            }
            return `Great idea! Now with the ${meal} we have ${Object.keys(this.menu).length} meals in the menu, other ideas?`
        } else {
            return `The ${meal} is already in the our menu, try something different.`;
        }
    }

    showTheMenu() {
        if (Object.keys(this.menu).length == 0) {
            return 'Our menu is not ready yet, please come later...';
        }
        let result = [];
        for (const key in this.menu) {
            result.push(`${key} - $ ${this.menu[key].price}`);
        }

        return result.join('\n');
    }

    makeTheOrder(mealName) {
        if (!this.menu.hasOwnProperty(mealName)) {
            return `There is not ${mealName} yet in our menu, do you want to order something else?`;
        } else {
            const meal = this.menu[mealName]; 
            for (const name in meal.products) {

                if (meal.products[name] <= this.stockProducts[name]) {
                    this.stockProducts[name] -= meal.products[name];
                } else {
                    return `For the time being, we cannot complete your order (${mealName}), we are very sorry...`;
                }
            }

            this.budgetMoney += meal.price;
            return `Your order (${mealName}) will be completed in the next 30 minutes and will cost you ${meal.price}.`
        }
    }
}

let kitchen = new Restaurant(1000);
console.log(kitchen.loadProducts(['Banana 10 5', 'Banana 20 10', 'Strawberries 50 30', 'Yogurt 10 10', 'Yogurt 500 1500', 'Honey 5 50']));
console.log(kitchen.loadProducts(['Banana 10 5', 'Banana 20 10', 'Strawberries 50 30', 'Yogurt 10 10', 'Yogurt 500 1500', 'Honey 5 50']));