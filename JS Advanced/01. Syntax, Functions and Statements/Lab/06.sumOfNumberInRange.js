function sumOfNumberInRange(n, m) {
    let result = 0;

    let start = Number(n);
    let end = Number(m);

    for (let i = start; i <= end; i++) {
        result += i;
    }

    console.log(result);

}

sumOfNumberInRange('1', '5' )