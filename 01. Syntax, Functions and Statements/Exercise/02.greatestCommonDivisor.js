function greatestCommonDivisor(num1, num2) {

    const min = Math.min(num1, num2);
    let gcd = 1;

    for (let i = 1; i <= min; i++) {

        if (num1 % i == 0 && num2 % i == 0) {
            gcd = i;
        }
    }

    console.log(gcd);
}

greatestCommonDivisor(15, 5);