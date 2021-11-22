/**
 * 
 * @param {Function} area 
 * @param {Function} vol 
 * @param {string} input 
 */
function solve(area, vol, input) {
    let cubes = JSON.parse(input);

    const output = [];
    for (const cube of cubes) {
        const cubeArea = area.apply(cube);
        const cubeVolume = vol.apply(cube);

        output.push({
            area: cubeArea,
            volume: cubeVolume
        });
    }

    return output;

}

solve(area, vol, `[
    {"x":"1","y":"2","z":"10"},
    {"x":"7","y":"7","z":"10"},
    {"x":"5","y":"2","z":"10"}
    ]`
);


function area() {
    return Math.abs(this.x * this.y);
};

function vol() {
    return Math.abs(this.x * this.y * this.z);
};
