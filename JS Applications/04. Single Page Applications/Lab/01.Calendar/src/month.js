import { showYearsTable } from './year.js';

const months = {
    'Jan': 1,
    'Feb': 2,
    'Mar': 3,
    'Apr': 4,
    'May': 5,
    'Jun': 6,
    'Jul': 7,
    'Aug': 8,
    'Sept': 9,
    'Oct': 10,
    'Nov': 11,
    'Dec': 12,
};


export function onSelectedMonth(targetMonthElement) {
    if (targetMonthElement.parentElement.closest('tr') != null) {
        const month = targetMonthElement.firstElementChild != null
            ? targetMonthElement.firstElementChild.textContent
            : targetMonthElement.textContent;
        
        const year = targetMonthElement.parentElement.closest('table').querySelector('caption').textContent;
        showMonth(month, year);
    } else if (targetMonthElement.tagName == 'CAPTION') {
        showYearsTable();
    }
}

function showMonth(month, year) {
    document.getElementById(`month-${year}-${months[month]}`).style.display = 'block';
    document.getElementById(`year-${year}`).style.display = 'none';
}
