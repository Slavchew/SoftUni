function solve() {
    let [name, hall, price] = document.querySelectorAll('#container input');
    let onScreenBtn = document.querySelector('#container button');
    onScreenBtn.addEventListener('click', onClick);
    let clearBtn = document.querySelector('#archive button');
    clearBtn.addEventListener('click', clear)
    
    let movieList = document.querySelector('#movies ul');
    let archiveList = document.querySelector('#archive ul');

    function onClick(e) {
        e.preventDefault();
        if (name.value !== '' && hall.value !== '' && price.value !== '' && !isNaN(Number(price.value))) {

            let li = document.createElement('li');

            let span = document.createElement('span');
            span.textContent = name.value;
            li.appendChild(span);

            let strong = document.createElement('strong');
            strong.textContent = `Hall: ${hall.value}`;
            li.appendChild(strong);

            let div = document.createElement('div');
            let strongInsideDiv = document.createElement('strong');
            strongInsideDiv.textContent = Number(price.value).toFixed(2);
            let input = document.createElement('input');
            input.placeholder = 'Tickets Sold';
            let btn = document.createElement('button');
            btn.addEventListener('click', addToArchive)
            btn.textContent = 'Archive';

            div.appendChild(strongInsideDiv);
            div.appendChild(input);
            div.appendChild(btn);

            li.appendChild(div);

            movieList.appendChild(li);

            name.value = '';
            hall.value = '';
            price.value = '';
        }
    }

    function addToArchive(e) {
        e.preventDefault();
        let ticketsSold = e.target.previousSibling;

        let movie = e.target.parentElement.parentElement;
        if (ticketsSold.value != '' && !isNaN(Number(ticketsSold.value))) {
            let li = document.createElement('li');

            let span = document.createElement('span');
            span.textContent = movie.children[0].textContent;
            li.appendChild(span);

            let strong = document.createElement('strong');
            strong.textContent = `Total amount: ${(Number(movie.children[2].children[0].textContent) * Number(ticketsSold.value)).toFixed(2)}`;
            li.appendChild(strong);

            let btn = document.createElement('button');
            btn.textContent = `Delete`;
            btn.addEventListener('click', onDelete)
            li.appendChild(btn);

            movieList.removeChild(movie);
            archiveList.appendChild(li);

        }
    }


    function onDelete(e) {
        e.preventDefault();
        archiveList.removeChild(e.target.parentElement);
    }

    function clear(e) {
        e.preventDefault();
        archiveList.innerHTML = "";
    }
}