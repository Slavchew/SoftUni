function yardGreening(input) {
    let area = Number(input[0]);
    let areaPrice = area * 7.61;

    let discount = areaPrice * 0.18;
    let finalPrice = areaPrice - discount;

    console.log(`The final price is: ${finalPrice.toFixed(2)} lv.`);
    console.log(`The discount is: ${discount.toFixed(2)} lv.`);
}
yardGreening(["550"])