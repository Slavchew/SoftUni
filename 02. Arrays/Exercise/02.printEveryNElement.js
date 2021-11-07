function solve(input, n) {
    let result = [];

    for (let i = 0; i < input.length; i += n) {
        result.push(input[i]);
    }

    return result;
}

console.log(solve([
    '5',
    '20',
    '31',
    '4',
    '20'],
    2
));