function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      let searchText = document.getElementById('searchField').value.toLowerCase();
      let rows = document.querySelectorAll('tbody tr');

      for (const row of rows) {
         
         let text = row.textContent.toLowerCase();
         if (text.includes(searchText)) {
            row.classList.add('select');
         } else {
            row.classList.remove('select');
         }
      }

      document.getElementById('searchField').value = '';
   }
}