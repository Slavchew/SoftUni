function create(words) {
   let output = document.getElementById('content');

   for (const word of words) {
      
      let div = document.createElement('div');
      let paragraph = document.createElement('p');
      paragraph.textContent = word;
      paragraph.style.display = 'none';

      div.addEventListener('click', onClick)
      div.appendChild(paragraph);

      output.appendChild(div);
   }

   function onClick(ev) {
      ev.target.children[0].style.display = '';
   }
}