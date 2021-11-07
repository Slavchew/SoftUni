function cookingByNumber(num, ...params) {

    num = Number(num);

    for (const cmd of params) {

        switch (cmd) {
            case 'chop':
                num /= 2;
                break;
            case 'dice':
                num = Math.sqrt(num);
                break;
            case 'spice':
                num += 1;
                break;
            case 'bake':
                num *= 3;
                break;
            case 'fillet':
                num *= 0.8;
                break;
        }

        console.log(num.toFixed(2));
    }
}

cookingByNumber('32', 'chop', 'chop', 'chop', 'chop', 'chop')