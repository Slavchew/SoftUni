function tradeCommissions(input) {
    
    let town = input[0];
    let sells = Number(input[1])

    if (town === "Sofia") {
        if (sells >= 0 && sells <= 500) {
            console.log((sells * 0.05).toFixed(2));
        } else if (sells > 500 && sells <= 1000) {
            console.log((sells * 0.07).toFixed(2));
        } else if (sells > 1000 && sells <= 10000) {
            console.log((sells * 0.08).toFixed(2));
        } else if (sells > 10000) {
            console.log((sells * 0.12).toFixed(2));
        } else {
            console.log("error");
        }
    } else if (town === "Varna") {
        if (sells >= 0 && sells <= 500) {
            console.log((sells * 0.045).toFixed(2));
        } else if (sells > 500 && sells <= 1000) {
            console.log((sells * 0.075).toFixed(2));
        } else if (sells > 1000 && sells <= 10000) {
            console.log((sells * 0.10).toFixed(2));
        } else if (sells > 10000) {
            console.log((sells * 0.13).toFixed(2));
        } else {
            console.log("error");
        }
    } else if (town === "Plovdiv") {
        if (sells >= 0 && sells <= 500) {
            console.log((sells * 0.055).toFixed(2));
        } else if (sells > 500 && sells <= 1000) {
            console.log((sells * 0.08).toFixed(2));
        } else if (sells > 1000 && sells <= 10000) {
            console.log((sells * 0.12).toFixed(2));
        } else if (sells > 10000) {
            console.log((sells * 0.145).toFixed(2));
        } else {
            console.log("error");
        }
    } else {
        console.log("error");
    }

}
tradeCommissions(["Plovdiv",
"499.99"])

