import { onSelectedMonth } from './month.js';
import { onSelectYear, showYear, showYearsTable } from './year.js';

const sections = document.querySelectorAll('section');
sections.forEach(x => x.addEventListener('click', onSelect));
sections.forEach(x => x.style.display = 'none');

const views = {
    'years': onSelectYear,
    'month': onSelectedMonth,
};

showYearsTable();

function onSelect(event) {
    const sectionId = event.target.parentElement.closest('section')?.id;

    if (sectionId != null) {

        if (sectionId.includes('month-') && event.target.tagName == 'CAPTION') {
            const year = event.target.textContent.split(' ')[1];
            document.getElementById(sectionId).style.display = 'none';
            showYear(year);
            return;
        }

        if (sectionId.includes('year-')) {
            const view = views['month'];
            if (typeof view == 'function') {
                const target = event.target;
                view(target);
            }

            return;
        }

        const view = views[sectionId];
        if (typeof view == 'function') {
            const target = event.target;
            view(target);
        }
    }
}