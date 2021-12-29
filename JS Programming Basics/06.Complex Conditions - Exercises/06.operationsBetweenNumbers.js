function operationsBetweenNumbers(input) {
    
    let a = Number(input[0]);
    let b = Number(input[1]);

    let sign = input[2];
    let result = 0;

    if (sign === "+") {
        result = a + b;
        if (result % 2 === 0) {
            console.log(`${a} + ${b} = ${result} - even`);
        } else {
            console.log(`${a} + ${b} = ${result} - odd`);
        }
    } else if (sign === "-") {
        result = a - b;
        if (result % 2 === 0) {
            console.log(`${a} - ${b} = ${result} - even`);
        } else {
            console.log(`${a} - ${b} = ${result} - odd`);
        }
    } else if (sign === "*") {
        result = a * b;
        if (result % 2 === 0) {
            console.log(`${a} * ${b} = ${result} - even`);
        } else {
            console.log(`${a} * ${b} = ${result} - odd`);
        }
    } else if (sign === "/") {
        if (a === 0) {
            console.log(`Cannot divide ${b} by zero`);
        } else if (b === 0){
            console.log(`Cannot divide ${a} by zero`);
        } else {
            result = a / b;
            console.log(`${a} / ${b} = ${result.toFixed(2)}`);
        }
    } else if (sign === "%") {
        if (a === 0) {
            console.log(`Cannot divide ${b} by zero`);
        } else if (b === 0){
            console.log(`Cannot divide ${a} by zero`);
        } else {
            result = a % b;
            console.log(`${a} % ${b} = ${result}`);  
        }
    }
}
operationsBetweenNumbers(["112",
"0",
"/"])

