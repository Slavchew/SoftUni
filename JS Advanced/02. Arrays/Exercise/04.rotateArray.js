/**
 * 
 * @param {[]} input 
 * @param {Number} n 
 */
function solve(input, n) {

    for (let i = 0; i < n; i++) {
        let num = input.pop();
        input.unshift(num);
    }

    return input.join(" ");
}
console.log(solve([
    '1',
    '2',
    '3',
    '4'],
    2
));