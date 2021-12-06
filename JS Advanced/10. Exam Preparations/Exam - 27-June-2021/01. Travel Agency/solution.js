window.addEventListener('load', solution);

function solution() {

    const nameInput = document.getElementById('fname');
    const emailInput = document.getElementById('email');
    const phoneInput = document.getElementById('phone');
    const addressInput = document.getElementById('address');
    const codeInput = document.getElementById('code');
    const submitBtn = document.getElementById('submitBTN');
    submitBtn.addEventListener('click', submit);

    const infoList = document.getElementById('infoPreview');

    const editBth = document.getElementById('editBTN');
    const continueBth = document.getElementById('continueBTN');

    editBth.addEventListener('click', edit);
    continueBth.addEventListener('click', continueFtn)

    let name;
    let email;
    let phone;
    let address;
    let code;

    function submit() {
        if (nameInput.value && emailInput.value) {

            infoList.appendChild(createElm('li', `Full Name: ${nameInput.value}`));
            infoList.appendChild(createElm('li', `Email: ${emailInput.value}`));
            infoList.appendChild(createElm('li', `Phone Number: ${phoneInput.value}`));
            infoList.appendChild(createElm('li', `Address: ${addressInput.value}`));
            infoList.appendChild(createElm('li', `Postal Code: ${codeInput.value}`));

            submitBtn.disabled = true;

            editBth.disabled = false;
            continueBth.disabled = false;

            name = nameInput.value;
            email = emailInput.value;
            phone = phoneInput.value;
            address = addressInput.value;
            code = codeInput.value;

            nameInput.value = '';
            emailInput.value = '';
            phoneInput.value = '';
            addressInput.value = '';
            codeInput.value = '';
        }
    }

    function edit(e) {
        submitBtn.disabled = false;

        editBth.disabled = true;
        continueBth.disabled = true;

        nameInput.value = name;
        emailInput.value = email;
        phoneInput.value = Number(phone);
        addressInput.value = address;
        codeInput.value = Number(code);

        e.target.parentNode.parentElement.children[0].innerHTML = '';
    }

    function continueFtn() {
        document.getElementById('block').innerHTML = '<h3>Thank you for your reservation!</h3>';
    }

    function createElm(type, text) {
        const li = document.createElement(type);
        li.textContent = text;

        return li;
    }
}
