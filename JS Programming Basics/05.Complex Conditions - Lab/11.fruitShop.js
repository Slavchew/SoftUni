function fruitShop(input) {
    
    let product = input[0];
    let day = input[1];
    let quantity = Number(input[2]);

    let errorMessage = "error";

    if (day === "Monday" || day === "Tuesday" || day === "Wednesday" 
    || day === "Thursday" || day === "Friday" ) {
        if (product === "banana") {
            console.log((quantity * 2.50).toFixed(2));
        } else if (product === "apple") {
            console.log((quantity * 1.20).toFixed(2));
        } else if (product === "orange") {
            console.log((quantity * 0.85).toFixed(2));
        } else if (product === "grapefruit") {
            console.log((quantity * 1.45).toFixed(2));
        } else if (product === "kiwi") {
            console.log((quantity * 2.70).toFixed(2));
        } else if (product === "pineapple") {
            console.log((quantity * 5.50).toFixed(2));
        } else if (product === "grapes") {
            console.log((quantity * 3.85).toFixed(2));
        } else {
            console.log(errorMessage);
        }
    } else if (day === "Saturday" || day === "Sunday") {
        if (product === "banana") {
            console.log((quantity * 2.70).toFixed(2));
        } else if (product === "apple") {
            console.log((quantity * 1.25).toFixed(2));
        } else if (product === "orange") {
            console.log((quantity * 0.90).toFixed(2));
        } else if (product === "grapefruit") {
            console.log((quantity * 1.60).toFixed(2))
        } else if (product === "kiwi") {
            console.log((quantity * 3.00).toFixed(2));
        } else if (product === "pineapple") {
            console.log((quantity * 5.60).toFixed(2));
        } else if (product === "grapes") {
            console.log((quantity * 4.20).toFixed(2));
        } else {
            console.log(errorMessage);
        }
    } else {
        console.log(errorMessage);
    }
}
fruitShop(["orange",
"Sunday",
"3"])


