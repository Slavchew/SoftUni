function cinema(input) {
    
    let screeningType = input[0];
    let rows = Number(input[1]);
    let columns = Number(input[2]);

    let price = 0;

    if (screeningType === "Premiere") {
        price = (rows * columns) * 12.00;
    } else if (screeningType === "Normal") {
        price = (rows * columns) * 7.50;
    } else if (screeningType === "Discount") {
        price = (rows * columns) * 5.00;
    }
    
    console.log(`${price.toFixed(2)} leva`);

}
cinema(["Premiere",
"10",
"12"])