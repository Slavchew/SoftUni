function lockedProfile() {
    Array.from(document.querySelectorAll('.profile button')).forEach(b => b.addEventListener('click', onToggle));

    function onToggle(e) {
        const divInfo = Array
        .from(e.target.parentElement.querySelectorAll('div'))
        .find(d => d.id.includes('HiddenFields'));

        const unlockBtn = e.target.parentElement.querySelector('input[value="unlock"]');
        if (unlockBtn.checked) {
            if (e.target.textContent == 'Show more') {
                divInfo.style.display = 'block'
                e.target.textContent = 'Hide it'
            } else {
                divInfo.style.display = ''
                e.target.textContent = 'Show more'
            }
        }
    }
}