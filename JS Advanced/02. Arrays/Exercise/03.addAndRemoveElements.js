function solve(input) {
    let num = 1;
    let result = [];

    for (let i = 0; i < input.length; i++) {
        if (input[i] === 'add') {
            result.push(num);
        } else if (input[i] === 'remove') {
            result.pop();
        }
        num++;
    }

    if (result.length > 0) {
        return result.join('\n');
    }
    return "Empty"
}
console.log(solve([
    'add',
    'add',
    'add',
    'add']
));