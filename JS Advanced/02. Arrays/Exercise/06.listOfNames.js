/**
 * 
 * @param {[]} input 
 * @returns 
 */
function solve(input) {
    input.sort((a, b) => a.localeCompare(b));
    let result = [];

    for (let i = 0; i < input.length; i++) {
        result.push(`${i + 1}.${input[i]}`);
    }

    return result.join('\n');

}
console.log(solve(["John", "Bob", "Christina", "Ema"]));