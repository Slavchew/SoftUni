const tableBody = document.getElementsByTagName('tbody')[0];
const form = document.getElementById('form');

function attachEvents() {
    loadStudents();

    form.addEventListener('submit', onSumbit);
}

async function loadStudents() {
    const res = await fetch('http://localhost:3030/jsonstore/collections/students');
    const data = await res.json();

    tableBody.innerHTML = '';
    for (const { firstName, lastName, facultyNumber, grade } of Object.values(data)) {
        tableBody.innerHTML += 
`<tr>
    <td>${firstName}</td>
    <td>${lastName}</td>
    <td>${facultyNumber}</td>
    <td>${grade.toFixed(2)}</td>
</tr>`;
    }
}

function onSumbit(event) {
    event.preventDefault();

    const formData = new FormData(form);

    const firstName = formData.get('firstName').trim();
    const lastName = formData.get('lastName').trim();
    const facultyNumber = formData.get('facultyNumber').trim();
    let grade = formData.get('grade').trim();

    if(!firstName || !lastName || !/^[0-9]+$/.test(facultyNumber) || !grade || isNaN(grade)) {
        console.log('One of the input fields is incorect');
        form.reset();
        return;
    }

    grade = Number(grade);
    form.reset();

    createStudent({ firstName, lastName, facultyNumber, grade });

    loadStudents();
}

function createStudent(data) {
    const options = {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(data),
    };

    fetch('http://localhost:3030/jsonstore/collections/students', options);
}

attachEvents();