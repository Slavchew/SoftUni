function solve() {
    let types = {};

    for (const arg of arguments) {
        let type = typeof arg;
        if (types[type] == undefined) {
            types[typeof arg] = 0;
        }
        types[type]++;
        console.log(`${typeof arg}: ${arg}`);
    }

    let counts = [];
    for (const type in types) {
        counts.push([type, types[type]]);
    }

    counts.sort((a, b) => b[1] - a[1]);

    for (const [type, count] of counts) {
        console.log(`${type} = ${count}`);
    }
}

solve({ name: 'bob'}, 3.333, 9.999)