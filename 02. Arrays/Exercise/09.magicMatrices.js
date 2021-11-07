function solve(input) {

    let sum = input[0].reduce((a, b) => a + b, 0);

    let isMagicMatrix = true;

    for (let row = 0; row < input.length; row++) {
        let rowSum = input[row].reduce((a, b) => a + b, 0);
    
        if (rowSum !== sum) {
            isMagicMatrix = false;
            break;
        }
        let colSum = 0;
        for (let col = 0; col < input[row].length; col++) {
            colSum += input[col][row];
        }

        if (colSum !== sum) {
            isMagicMatrix = false;
            break;
        }
    }

    return isMagicMatrix;
}
console.log(solve([
    [4, 5, 6],
    [4, 5, 6],
    [4, 5, 6]]
));

console.log(solve([
    [11, 32, 45],
    [21, 0, 1],
    [21, 1, 1]]
));

console.log(solve([
    [1, 0, 0],
    [0, 0, 1],
    [0, 1, 0]]
));