function encodeAndDecodeMessages() {
    Array.from(document.getElementsByTagName('button')).forEach(b => b.addEventListener('click', onClick));


    function onClick(e) {
        let btnText = e.target.textContent;

        let output = e.target.parentElement.parentElement.querySelectorAll('div')[1].querySelector('textarea');
        if (btnText == 'Encode and send it') {
            let textBox = e.target.parentElement.querySelector('textarea');
            let encodedText = '';
            Array.from(textBox.value).forEach(e => {
                encodedText += String.fromCharCode(e.charCodeAt(0) + 1);
            });;

            textBox.value = '';
            output.value = encodedText;
            
        } else {
            let decodedText = '';
            Array.from(output.value).forEach(e => {
                decodedText += String.fromCharCode(e.charCodeAt(0) - 1);
            });;

            output.value = decodedText;
        }
    }
}