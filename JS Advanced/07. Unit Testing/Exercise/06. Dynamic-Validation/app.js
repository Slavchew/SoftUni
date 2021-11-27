function validate() {
    let input = document.getElementById('email');
    const pattern = /^([a-z]+@[a-z]+\.[a-z]+)$/g;

    input.addEventListener('change', onChange)

    function onChange(e) {
        if (!pattern.test(input.value)) {
            input.classList.add('error');
        } else {
            input.classList.remove('error');
        }
    }

    input.value = '';
}