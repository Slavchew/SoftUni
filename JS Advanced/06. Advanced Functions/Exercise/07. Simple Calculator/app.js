function calculator() {
    let firstInput;
    let secondInput;
    let resultInput;

    function init(selector1, selector2, resultSelector) {
        firstInput = document.querySelector(selector1);
        secondInput = document.querySelector(selector2);
        resultInput = document.querySelector(resultSelector);
    }

    function add() {
        let num1 = Number(firstInput.value);
        let num2 = Number(secondInput.value);
        let sum = num1 + num2
        resultInput.value = sum;
    }

    function subtract() {
        let num1 = Number(firstInput.value);
        let num2 = Number(secondInput.value);
        let sum = num1 - num2
        resultInput.value = sum;
    }

    return {
        init,
        add,
        subtract
    }
}

const calculate = calculator (); 
calculate.init('#num1', '#num2', '#result');





