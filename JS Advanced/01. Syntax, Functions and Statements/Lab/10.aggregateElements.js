function aggregateElements(input) {
    let sum = 0;
    let otherSum = 0;
    let concat = "";

    for (let i = 0; i < input.length; i++) {
        sum += Number(input[i]);
        otherSum += (1 / Number(input[i]));
        concat += input[i];
    }

    console.log(sum);
    console.log(otherSum);
    console.log(concat);
}

aggregateElements([2, 4, 8, 16])