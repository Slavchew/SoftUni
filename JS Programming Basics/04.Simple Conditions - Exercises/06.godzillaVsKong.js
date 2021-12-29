function godzillaVsKong(input) {
    
    let filmBudget = Number(input[0]);
    let extras = Number(input[1]);
    let extraClothPrice = Number(input[2]);

    let filmDecor = filmBudget * 0.10;

    if (extras > 150) {
        extraClothPrice *= 0.90;
    }

    let sum = filmDecor + (extras * extraClothPrice);
    if (sum <= filmBudget) {
        console.log("Action!");
        console.log(`Wingard starts filming with ${(filmBudget - sum).toFixed(2)} leva left.`);
    }
    else {
        console.log("Not enough money!");
        console.log(`Wingard needs ${(sum - filmBudget).toFixed(2)} leva more.`);
    }
}
godzillaVsKong(["20000",
"120",
"55.5"])