function fruitMarket(input) {
    let strawberryPrice = Number(input[0]);
    let bananasKg = Number(input[1]);
    let orangesKg = Number(input[2]);
    let raspberriesKg = Number(input[3]);
    let strawberryKg = Number(input[4]);

    let raspberriesPrice = strawberryPrice / 2;
    let orangesPrice = raspberriesPrice * 0.60;
    let bananasPrice = raspberriesPrice * 0.20;

    let strawberrySum = strawberryPrice * strawberryKg;
    let bananasSum = bananasPrice * bananasKg;
    let orangesSum = orangesPrice * orangesKg;
    let raspberriesSum = raspberriesPrice * raspberriesKg;

    let finalSum = strawberrySum + bananasSum + orangesSum + raspberriesSum;

    console.log(finalSum);
}
fruitMarket(["48",
"10",
"3.3",
"6.5",
"1.7"])
