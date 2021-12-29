function unitConvertor(input) {
    
    let num = Number(input[0]);
    let firstUnit = input[1];
    let secondUnit = input[2];

    let result = 0;

    if (firstUnit === "mm") {
        if (secondUnit === "mm") {
            result = num;
        } else if (secondUnit === "cm"){
            result = num / 10;
        } else if (secondUnit === "m"){
            result = num / 1000;
        }
    }
    else if (firstUnit === "cm") {
        if (secondUnit === "mm") {
            result = num * 10;
        } else if (secondUnit === "cm"){
            result = num;
        } else if (secondUnit === "m"){
            result = num / 100;
        }
    }
    else if (firstUnit === "m") {
        if (secondUnit === "mm") {
            result = num * 1000;
        } else if (secondUnit === "cm"){
            result = num * 100;
        } else if (secondUnit === "m"){
            result = num;
        }
    }

    console.log(result.toFixed(3));

}
unitConvertor(["45","cm","mm"])