function addItem() {
    let input = document.getElementById('newItemText');

    let li = document.createElement('li');
    li.textContent = input.value;

    const button = document.createElement('a');
    button.href = '#';
    button.textContent = '[Delete]';
    button.addEventListener('click', removeElement)

    li.appendChild(button);

    document.getElementById('items').appendChild(li);

    input.value = '';


    function removeElement(ev) {
        let parent = ev.target.parentNode;
        parent.remove();
    }
}