function solve(input) {
    input.sort((a, b) => a - b);
    let result = input.slice(0, 2);

    return result;
}

console.log(solve([30, 15, 50, 5]));