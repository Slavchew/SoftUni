function extractText() {
    const items = document.querySelectorAll('#items li')
    let result = [];

    for (const item of Array.from(items)) {
        result.push(item.textContent);
    }

    document.getElementById('result').value = result.join('\n');
}