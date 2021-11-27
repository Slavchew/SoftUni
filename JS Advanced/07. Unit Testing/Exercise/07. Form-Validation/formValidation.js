function validate() {
    const usernameInput = document.getElementById('username');
    usernameInput.value = '';
    const emailInput = document.getElementById('email');
    emailInput.value = '';
    const passwordInput = document.getElementById('password');
    passwordInput.value = '';
    const confirmPasswordInput = document.getElementById('confirm-password');
    confirmPasswordInput.value = '';
    const companyCheckBox = document.querySelector('input[id="company"][type="checkbox"]');
    companyCheckBox.checked = false;

    const companyInfoField = document.getElementById('companyInfo');
    const companyNumberInput = document.getElementById('companyNumber');
    companyNumberInput.value = '';

    const usernamePattern = /^([a-zA-Z0-9]{3,20})$/;
    const emailPattern = /^(.)*@(.)*\.(.)*$/;
    const passwordPattern = /^([\w]{5,15})$/;

    const submitBtn = document.getElementById('submit');
    submitBtn.addEventListener('click', onClick);


    function onClick(event) {
        event.preventDefault();
        let isValidInput = true;
        if (!usernamePattern.test(usernameInput.value)) {
            isValidInput = false;
            usernameInput.style = 'border-color: red';
        } else {
            usernameInput.style = 'border: none';
        }

        if (!emailPattern.test(emailInput.value)) {
            isValidInput = false;
            emailInput.style = 'border-color: red';
        } else {
            emailInput.style = 'border: none';
        }

        if (!passwordPattern.test(passwordInput.value) || !passwordPattern.test(confirmPasswordInput.value) 
            || confirmPasswordInput.value !== passwordInput.value) {
            isValidInput = false;
            passwordInput.style = 'border-color: red';
            confirmPasswordInput.style = 'border-color: red';
        } else {
            passwordInput.style = 'border: none';
            confirmPasswordInput.style = 'border: none';
        }

        if (companyCheckBox.checked) {
            if (Number(companyNumberInput.value) < 1000 || Number(companyNumberInput.value) > 9999) {
                isValidInput = false;
                companyNumberInput.style = 'border-color: red';
            } else {
                companyNumberInput.style = 'border: none';
            }
        }

        if (isValidInput) {
            document.getElementById('valid').style.display = 'block';
        } else {
            document.getElementById('valid').style.display = 'none';
        }
    }

    companyCheckBox.addEventListener('change', () => {
        if (companyCheckBox.checked) {
            companyInfoField.style.display = 'block';
        } else {
            companyInfoField.style.display = 'none';
        }
    })
}
