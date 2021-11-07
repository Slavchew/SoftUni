function depositCalculator(input) {
    let sum = Number(input[0]);
    let months = Number(input[1]);
    let annualRate = Number(input[2]);

    let tax = sum * (annualRate / 100 );
    let monthTax = tax / 12;

    let result = sum + (months * monthTax);

    console.log(result.toFixed(2));
    
}
depositCalculator(["200", "3", "5.7"])