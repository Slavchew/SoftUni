function solve(matrix) {

    let equalPairs = 0;

    for (var i = 0; i < matrix.length - 1; i++) {
        for (let j = 1; j < matrix[i].length; j++) {
            if (matrix[i][j] == matrix[i + 1][j]
                || matrix[i][j] == matrix[i][j - 1]) {
                equalPairs++;
            }
        }
    }

    for (let i = 0; i < matrix[matrix.length - 1].length; i++) {
        if (matrix[matrix.length - 1][i] == matrix[matrix.length - 1][i + 1]) {
            equalPairs++;
        }
    }
    for (let i = 0; i < matrix.length - 1; i++) {
        if (matrix[i][0] == matrix[i + 1][0]) {
            equalPairs++;
        }
    }


    return equalPairs;
}

let array = [
    ['test', 'yes', 'yo', 'ho'],
    ['well', 'done', 'yo', '6'],
    ['not', 'done', 'yet', '5']];
console.log(solve(array));
