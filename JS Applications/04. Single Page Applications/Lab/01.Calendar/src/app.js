import { onSelectYear, showYearsTable } from './year.js';

const sections = document.querySelectorAll('section');
sections.forEach(x => x.addEventListener('click', onSelect));
sections.forEach(x => x.style.display = 'none');

const views = {
    'years': onSelectYear
};

showYearsTable();

function onSelect(event) {
    // sections.forEach(x => x.style.display = 'none');
    const sectionId = event.target.parentElement.closest('section')?.id;

    if (sectionId != null) {
        const target = event.target;

        const view = views[sectionId];
        view(target);
    }
}