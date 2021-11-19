function focused() {
    Array
        .from(document.getElementsByTagName('input'))
        .forEach(f => {
            f.addEventListener('focus', onFocus);
            f.addEventListener('blur', onBlur);
        });

    function onFocus(ev) {
        ev.target.parentNode.classList.add('focused');
    }

    function onBlur(ev) {
        ev.target.parentNode.classList.remove('focused');
    }
}