function solve() {
    const nameInput = document.querySelector('input[placeholder="Name"]');
    const ageInput = document.querySelector('input[placeholder="Age"]');
    const kindInput = document.querySelector('input[placeholder="Kind"]');
    const ownerInput = document.querySelector('input[placeholder="Current Owner"]');
    const adoptionList = document.querySelector('#adoption ul');
    const adoptedList = document.querySelector('#adopted ul');

    const addBtn = document.querySelector('#container button');
    addBtn.addEventListener('click', addPet);

    function addPet(e) {
        e.preventDefault();
        if (nameInput.value && ageInput.value && !Number.isNaN(Number(ageInput.value)) && kindInput.value && ownerInput.value) {
            const li = document.createElement('li');
            const p = document.createElement('p');
            p.innerHTML =`<strong>${nameInput.value}</strong> is a <strong>${ageInput.value}</strong> year old <strong>${kindInput.value}</strong>`;

            const span = document.createElement('span');
            span.textContent = `Owner: ${ownerInput.value}`;

            const contactBtn = document.createElement('button');
            contactBtn.textContent = 'Contact with owner';
            contactBtn.addEventListener('click', contact);

            li.appendChild(p);
            li.appendChild(span);
            li.appendChild(contactBtn);

            adoptionList.appendChild(li);
        }

        nameInput.value = '';
        ageInput.value = '';
        kindInput.value = '';
        ownerInput.value = '';

    }

    function contact(e) {
        const div = document.createElement('div');

        const input = document.createElement('input');
        input.setAttribute('placeholder', 'Enter your names');

        const adoptBtn = document.createElement('button');
        adoptBtn.textContent = 'Yes! I take it!';
        adoptBtn.addEventListener('click', adopt);

        div.appendChild(input);
        div.appendChild(adoptBtn);

        e.target.parentNode.appendChild(div);
        e.target.remove();
    }

    function adopt(e) {
        if (e.target.previousSibling.value) {
            const li = e.target.parentNode.parentNode;

            const span = li.childNodes[1];
            span.textContent = `New Owner: ${e.target.previousSibling.value}`;
            console.log(span);

            li.childNodes[2].remove();

            const checkedBtn = document.createElement('button');
            checkedBtn.textContent = 'Checked';
            checkedBtn.addEventListener('click', checked)

            li.appendChild(checkedBtn);

            adoptedList.appendChild(li);
        }
    }

    function checked(e) {
        e.target.parentNode.remove();
    }
}

