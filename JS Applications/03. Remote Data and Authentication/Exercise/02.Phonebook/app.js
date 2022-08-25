const contactsUl = document.getElementById('phonebook');
const loadContactsBtn = document.getElementById('btnLoad');
const createContactBtn = document.getElementById('btnCreate');

const personInput = document.getElementById('person');
const phoneInput = document.getElementById('phone');

function attachEvents() {
    loadContactsBtn.addEventListener('click', loadContacts);

    loadContacts();

    createContactBtn.addEventListener('click', onCreate);
}

async function onCreate() {
    const person = personInput.value;
    const phone = phoneInput.value;

    await createContact({person, phone});
}

async function loadContacts() {
    const res = await fetch('http://localhost:3030/jsonstore/phonebook');
    const data = await res.json();

    contactsUl.replaceChildren();

    for (const phoneObj of Object.values(data)) {
        const li = document.createElement('li');
        li.textContent = `${phoneObj.person}: ${phoneObj.phone}`;

        const deleteBtn = document.createElement('button');
        deleteBtn.innerHTML = 'Delete';
        deleteBtn.setAttribute('data-id', phoneObj._id)
        deleteBtn.addEventListener('click', deleteContact);

        li.appendChild(deleteBtn);
        contactsUl.appendChild(li);
    }


}

async function createContact(contact) {
    const res = await fetch('http://localhost:3030/jsonstore/phonebook', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(contact),
    });

    const result = await res.json();

    return result;
}

function deleteContact(event) {
    event.preventDefault();

    const url = 'http://localhost:3030/jsonstore/phonebook/' + event.target.dataset.id;

    const options = {
        method: 'DELETE',
    }

    fetch(url, options)

    event.target.parentElement.remove();
}

attachEvents();