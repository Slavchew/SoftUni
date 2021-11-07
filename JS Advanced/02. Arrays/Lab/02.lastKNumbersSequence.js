function solve(n, k) {
    let sequence = [1];

    for (let i = 1; i < n; i++) {
        let startIndex = Math.max(0, i - k);
        let currentElement = sequence.slice(startIndex, startIndex + k).reduce((a, b) => a + b, 0);
        sequence.push(currentElement);
    }

    return sequence;
}

solve(6, 3);