const nameInput = document.querySelector('[name=author]');
const contentInput = document.querySelector('[name=content]');

const createBtn = document.getElementById('submit');
const loadDataBtn = document.getElementById('refresh');

const dataDiv = document.getElementById('messages');

function attachEvents() {
    createBtn.addEventListener('click', createMessage);

    loadDataBtn.addEventListener('click', loadMessages)
}

function createMessage() {
    const url = 'http://localhost:3030/jsonstore/messenger';

    const body = {
        author: nameInput.value.trim(),
        content: contentInput.value.trim(),
    };

    const options = {
        method: "POST",
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(body),
    };

    fetch(url, options);
}

async function loadMessages() {
    const url = 'http://localhost:3030/jsonstore/messenger';

    const res = await fetch(url);
    const data = await res.json();

    let messagesText = [];
    for (const {author, content} of Object.values(data)) {
        messagesText.push(`${author}: ${content}`);
    }

    dataDiv.textContent = messagesText.join('\n');
}

attachEvents();