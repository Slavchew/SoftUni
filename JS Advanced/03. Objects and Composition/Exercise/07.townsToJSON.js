function solve(arr) {
    const result = [];

    const columns = arr[0].substring(2, arr[0].length - 2);

    const [town, latitude, longitude] = columns.split(" | ");
    for (let i = 1; i < arr.length; i++) {
        const obj = {};

        const data = arr[i].substring(2, arr[i].length - 2);
        let [currTown, currLatitude, currLongitude] = data.split(" | ");

        obj[town] = currTown;
        obj[latitude] = Number(Number(currLatitude).toFixed(2));
        obj[longitude] = Number(Number(currLongitude).toFixed(2));
        result.push(obj)
    }

    return JSON.stringify(result);
}

console.log(solve(
    [
        '| Town | Latitude | Longitude |',
        '| Sofia | 42.696552 | 23.32601 |',
        '| Beijing | 39.913818 | 116.363625 |'
    ]
));