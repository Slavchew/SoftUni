function search() {
   let matchesCount = 0;

   let towns = Array.from(document.querySelectorAll('ul li'));
   let searchedText = document.getElementById('searchText').value;

   towns.forEach((el) => {
      if (el.innerHTML.includes(searchedText)) {
         el.style.fontWeight = 'bold';
         el.style.textDecoration = 'underline';
         matchesCount++;
      } else {
         el.style.fontWeight = 'normal';
         el.style.textDecoration = '';
      }
   })

   document.getElementById('result').textContent = `${matchesCount} matches found`;
}
