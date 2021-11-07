function solve(input) {
    let first = Number(input.shift());
    let last = Number(input.pop());

    return first + last;
}

console.log(solve(['20', '30', '40']));
console.log(solve(['5', '10']));