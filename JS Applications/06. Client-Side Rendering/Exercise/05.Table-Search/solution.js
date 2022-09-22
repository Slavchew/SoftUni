import { html, render } from './node_modules/lit-html/lit-html.js';

const studentTemplate = (student) => html`
<tr class=${student.match ? 'select' : '' }>
    <td>${student.item.firstName} ${student.lastName}</td>
    <td>${student.item.email}</td>
    <td>${student.item.course}</td>
</tr>`;

// Start
const input = document.getElementById('searchField');
document.getElementById('searchBtn').addEventListener('click', onSearch);
let students;
getData();



function update() {
    render(students.map(studentTemplate), document.querySelector('tbody'));
}

async function getData() {
    const res = await fetch('http://localhost:3030/jsonstore/advanced/table');
    const data = await res.json();
    students = Object.values(data).map(s => ({ item: s, match: false }));

    update();
}

function onSearch() {
    const value = input.value.trim().toLocaleLowerCase();

    for (const student of students) {
        student.match = Object.values(student.item).some(x => value && x.toLocaleLowerCase().includes(value));
    }

    update();
}