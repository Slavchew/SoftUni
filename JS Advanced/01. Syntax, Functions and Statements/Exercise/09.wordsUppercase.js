function solve(str) {
    const regex = /\w+/g;
    let m;

    let result = [];

    while ((m = regex.exec(str)) !== null) {
        // This is necessary to avoid infinite loops with zero-width matches
        if (m.index === regex.lastIndex) {
            regex.lastIndex++;
        }

        m.forEach((match) => {
            result.push(match.toUpperCase());
        });
    }

    console.log(result.join(', '));
}

solve('Hi, how are you?')