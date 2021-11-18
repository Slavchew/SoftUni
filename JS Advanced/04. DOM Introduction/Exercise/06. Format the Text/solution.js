function solve() {
  let text = document.getElementById('input').value;

  let sentences = text.split('.').filter(x => x != '');
  let paras = [];
  let paragraph = [];

  for (let i = 0; i < sentences.length; i += 3) {
    for (let j = 0; j < 3; j++) {
      if (sentences[i + j] != undefined) {
        paragraph.push(sentences[i + j]);
      }
    }
    paras.push(paragraph.join('. ') + '.');
    paragraph.splice(0,paragraph.length);
  }


  let output = document.getElementById('output');
  output.innerHTML = '';
  for (const para of paras) {
    let text = `<p>${para}</p>`
    output.innerHTML += text;
  }
}