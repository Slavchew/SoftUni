const phonesUl = document.getElementById('phonebook');
const loadPhonesBtn = document.getElementById('btnLoad');

function attachEvents() {
    loadPhonesBtn.addEventListener('click', loadPhones)
}

async function loadPhones() {
    const url = 'http://localhost:3030/jsonstore/phonebook';

    const res = await fetch(url);
    const data = await res.json();

    for (const phoneObj of Object.values(data)) {
        const li = document.createElement('li');
        li.textContent = `${phoneObj.person}: ${phoneObj.phone}`;
        
        const deleteBtn = document.createElement('btn');
        deleteBtn.addEventListener('click', deletePhone(event, phoneObj._id));

        li.appendChild(deleteBtn);
        phonesUl.appendChild(li);
    }


}

function deletePhone(e, id) {
    e.preventDefault();

    const url = 'http://localhost:3030/jsonstore/phonebook/' + id;

    const options = {
        method: 'DELETE',
    }

    fetch(url, options)
}

attachEvents();