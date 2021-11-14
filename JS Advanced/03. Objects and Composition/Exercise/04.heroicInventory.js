function solve(input) {
    const result = [];

    input.forEach((el) => {
        let [name, level, items] = el.split(" / ");
        result.push({
            name,
            level: Number(level),
            items: items ? items.split(", ") : []
        });
    });

    return JSON.stringify(result);
}

console.log(solve([
    'Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara']
));