function solve() {
  let input = document.getElementById('text').value;
  let currentCase = document.getElementById('naming-convention').value;

  input = input.toLowerCase();

  words = input.split(' ');

  let result = '';

  if (currentCase === 'Camel Case') {
    result = convert(1);
  } else if (currentCase === 'Pascal Case') {
    result = convert(0);
  } else {
    result = 'Error!';
  }

  document.getElementById('result').textContent = result;


  function convert(startIndex) {
    for (let i = startIndex; i < words.length; i++) {
      words[i] = words[i][0].toUpperCase() + words[i].slice(1);
    }

    return words.join('');
  }
}