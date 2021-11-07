function sameNumbers(input) {
    let sum = 0;
    let isSame = true;
    const num = input.toString();

    let firstNum = num[0];
    for (let i = 0; i < num.length; i++) {
        if (num[i] != firstNum) {
            isSame = false;
        }
        sum += Number(num[i])
    }

    console.log(isSame);
    console.log(sum);
}

sameNumbers(1234)