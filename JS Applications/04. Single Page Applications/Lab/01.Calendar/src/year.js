const yearsTable = document.getElementById('years');

export function showYearsTable() {
    const sections = document.querySelectorAll('section');
    sections.forEach(x => x.style.display = 'none');
    yearsTable.style.display = 'block';
}

export function onSelectYear(targetYearElement) {
    if (targetYearElement.parentElement.closest('tr')?.className == 'days') {
        const year = targetYearElement.firstElementChild != null
            ? targetYearElement.firstElementChild.textContent
            : targetYearElement.textContent;

        showYear(year);
    }
}

export function showYear(year) {
    document.getElementById(`year-${year}`).style.display = 'block';
    document.getElementById('years').style.display = 'none';
}