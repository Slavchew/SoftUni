function charityCampaign(input) {
    let days = Number(input[0]);
    let confectioners = Number(input[1]);
    let cakes = Number(input[2]);
    let waffles = Number(input[3]);
    let pancakes = Number(input[4]);

    let cakesSum = cakes * 45;
    let wafflesSum = waffles * 5.80;
    let pancakesSum = pancakes * 3.20;

    let sum = (cakesSum + wafflesSum + pancakesSum) * confectioners;

    let sumOfWholeCampaign = sum * days;

    let result = sumOfWholeCampaign * (7/8);

    console.log(result);
}
charityCampaign(["23",
"8",
"14",
"30",
"16"])
