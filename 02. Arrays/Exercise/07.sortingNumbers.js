function solve(input) {

    let result = [];
    input.sort((a, b) => a - b);


    while (input.length > 0) {
        let small = input.shift();
        let big = input.pop();

        result.push(small, big);
    }

    return result;
}

console.log(solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));