function deleteByEmail() {
    let input = document.getElementsByName('email')[0];


    let rows = Array.from(document.querySelectorAll('tbody tr'));

    let isRemoved = false;
    for (const row of rows) {
        if (row.children[1].textContent == input.value) {
            row.remove();
            isRemoved = true;
        }
    }

    document.getElementById('result').textContent = isRemoved ? 'Deleted.' : 'Not found.';


}