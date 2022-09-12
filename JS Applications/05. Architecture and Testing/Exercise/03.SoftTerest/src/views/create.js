import { createIdea } from '../api/data.js';
import { e } from '../dom.js';

const section = document.getElementById('createPage');
section.remove();
const form = section.querySelector('form');
form.addEventListener('submit', onSubmit);
let ctx = null;

export async function showCreatePage(ctxTarget) {
    ctx = ctxTarget;
    ctx.showSection(section);
}

async function onSubmit(event) {
    event.preventDefault();
    const formData = new FormData(form);
    
    const title = formData.get('title').trim();
    const description = formData.get('description').trim();
    const img = formData.get('imageURL').trim();

    if (title.length < 6) {
        return alert('Title should be at least 6 characters long');
    }

    if (description.length < 10) {
        return alert('Description should be at least 10 characters long');
    }

    if (img.length < 5) {
        return alert('Image URL should be at least 5 characters long');
    }

    createIdea({title, description, img});
    form.reset();
    ctx.goTo('catalog');
}