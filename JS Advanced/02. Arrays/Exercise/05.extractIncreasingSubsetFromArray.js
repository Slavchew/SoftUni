/**
 * 
 * @param {[]} input 
 * @returns 
 */
function solve(input) {

    let result = [input[0]];
    let currentBiggest = input[0];
    for (let i = 1; i < input.length; i++) {
        if (currentBiggest <= input[i]) {
            result.push(input[i]);
            currentBiggest = input[i];
        }
    }

    return result;
}
console.log(solve([
    20,
    3,
    2,
    15,
    6,
    1]
));