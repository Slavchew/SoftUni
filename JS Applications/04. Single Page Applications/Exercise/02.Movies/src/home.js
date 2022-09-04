import { e, showView } from './dom.js';
import { showCreate } from './create.js';
import { showDetails } from './details.js';

const section = document.getElementById('home-page');
const catalog = section.querySelector('#catalogDiv');
section.querySelector('#createLink').addEventListener('click', (event) => {
    event.preventDefault();
    showCreate();
});
catalog.addEventListener('click', (event) => {
    event.preventDefault();
    let target = event.target;
    if (target.tagName == 'BUTTON') {
        target = target.parentElement;
    }

    if (target.tagName == 'A') {
        const id = target.dataset.id;
        showDetails(id);
    }
});
section.remove();

export function showHome() {
    showView(section);
    getMovies();
}

async function getMovies() {
    catalog.replaceChildren(e('p', {}, 'Loading...'));
    
    const res = await fetch('http://localhost:3030/data/movies');
    const data = await res.json();

    catalog.replaceChildren(...data.map(createMovieCard));
}

function createMovieCard(movie) {
    const element = e('div', {className: 'card md-4'});
    element.innerHTML = `
    <img class="card-img-top" src="${movie.img}"
        alt="Card image cap" width="400">
    <div class="card-body">
        <h4 class="card-title">${movie.title}</h4>
    </div>
    <div class="card-footer">
        <a data-id="${movie._id}" href="#">
            <button type="button" class="btn btn-info">Details</button>
        </a>
    </div>`;

    return element;
}