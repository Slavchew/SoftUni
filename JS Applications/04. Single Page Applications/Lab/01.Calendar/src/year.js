import { showMonths } from './month.js';

const yearsTable = document.getElementById('years');

export function showYearsTable() {
    yearsTable.style.display = 'block';
}

export function onSelectYear(targetYearElement) {
    if (targetYearElement.parentElement.closest('tr')?.className == 'days') {
        const year = targetYearElement.firstElementChild != null
            ? targetYearElement.firstElementChild.textContent
            : targetYearElement.textContent;

        showMonths(year);
    }
}