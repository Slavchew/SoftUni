function validate() {
    document.getElementById('email').addEventListener('change', onChange);

    function onChange({target}) {
        const pattern = /^[a-z]+@[a-z]+\.[a-z]+$/;

        if (pattern.test(target.value)) {
            target.classList.remove('error');
        } else {
            target.classList.add('error');
        }
    }
}