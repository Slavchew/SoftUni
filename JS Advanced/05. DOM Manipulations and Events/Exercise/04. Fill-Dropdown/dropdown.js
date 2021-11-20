function addItem() {
    let btn = document.querySelector('input[type="button"][value="Add"]');

    let textBox = btn.parentElement.querySelector('input[type="text"][id="newItemText"]');
    let valueBox = btn.parentElement.querySelector('input[type="text"][id="newItemValue"]');

    let option = document.createElement('option');
    option.textContent = textBox.value;
    option.value = valueBox.value;

    document.getElementById('menu').appendChild(option);

    textBox.value = '';
    valueBox.value = '';
}