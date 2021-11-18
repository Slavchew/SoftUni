function solve() {

    let menuTo = document.getElementById('selectMenuTo');

    // Binary
    var optBinary = document.createElement('option');
    optBinary.value = 'binary';
    optBinary.innerHTML = 'Binary';
    menuTo.appendChild(optBinary);

    //Hexadecimal
    var optHexadecimal = document.createElement('option');
    optHexadecimal.value = 'hexadecimal';
    optHexadecimal.innerHTML = 'Hexadecimal';
    menuTo.appendChild(optHexadecimal);


    document.querySelector('button').addEventListener('click', onClick);

    function onClick() {
        let input = Number(document.getElementById('input').value);
        let outputSystem = document.getElementById('selectMenuTo').value;

        let result = '';
        if (outputSystem == 'binary') {
            result = input.toString(2);
        } else if (outputSystem == 'hexadecimal') {
            result = input.toString(16).toUpperCase();
        }

        document.getElementById('result').value = result;
    }
}