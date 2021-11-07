/**
 * 
 * @param {[]} input 
 */
function solve(input) {
    
    let result = input.filter((x, i) => i % 2 != 0).map(x => x * 2).reverse();

    return result;
}

console.log(solve([10, 15, 20, 25]));