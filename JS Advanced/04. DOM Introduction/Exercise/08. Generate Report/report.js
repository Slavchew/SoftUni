function generateReport() {
    let inputElements = Array.from(document.getElementsByTagName('input'));
    
    const resultArr = [];
    const checkedCols = [];
    let tableRows = Array.from(document.getElementsByTagName('tr'));

    for (let i = 0; i < inputElements.length; i++) {
        if (inputElements[i].checked) {
            checkedCols.push(i);
        }
    }

    for (let i = 1; i < tableRows.length; i++) {
        const row = tableRows[i];
        const obj = {};

        for (let y = 0; y < row.children.length; y++) {
            const element = row.children[y];

            if (checkedCols.includes(y)) {
                let propertyName = inputElements[y].name;
                obj[propertyName] = element.textContent;
            }
        }
        resultArr.push(obj);
    }
    
    document.getElementById('output').value = JSON.stringify(resultArr);
}