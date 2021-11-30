class Contact {
    constructor(firstName, lastName, phone, email) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.phone = phone;
        this.email = email;
        this._online = false;
    }


    get online() {
        return this._online;
    }

    set online(value) {
        
        if (this.titleDiv && value == false) {
            this.titleDiv.classList.remove('online');
        } else if (this.titleDiv) {
            this.titleDiv.classList.add('online');
        }
        this._online = value;
    }

    render(id) {
        const article = document.createElement('article');

        this.titleDiv = document.createElement('div');
        this.titleDiv.classList.add('title');
        this.titleDiv.innerHTML = `${this.firstName} ${this.lastName}<button>&#8505;</button>`;

        if (this._online) {
            this.titleDiv.classList.add('online')
        }
        
        const infoDiv = document.createElement('div');
        infoDiv.classList.add('info');
        infoDiv.style.display = 'none';
        infoDiv.innerHTML = `<span>&phone; ${this.phone}</span><span>&#9993; ${this.email}</span>`;
        
        const btn = this.titleDiv.querySelector('button')
        btn.addEventListener('click', () => {
            infoDiv.style.display = infoDiv.style.display == 'none' ? 'block' : 'none';
        });
        
        article.appendChild(this.titleDiv);
        article.appendChild(infoDiv);

        document.getElementById(id).appendChild(article);
    }
}

let contacts = [
    new Contact("Ivan", "Ivanov", "0888 123 456", "i.ivanov@gmail.com"),
    new Contact("Maria", "Petrova", "0899 987 654", "mar4eto@abv.bg"),
    new Contact("Jordan", "Kirov", "0988 456 789", "jordk@gmail.com")
  ];
  contacts.forEach(c => c.render('main'));
  // After 1 second, change the online status to true
  setTimeout(() => contacts[1].online = true, 2000);
  