function solve(input, order) {
    if (order === 'asc') {
        return input.sort((a, b) => a - b);
    } else if (order === 'desc') {
        return input.sort((a, b) => b - a);
    }
}

console.log(solve([14, 7, 17, 6, 8], 'asc'));