class List {
    constructor() {
        this.numbers = [];
        this.size = 0;
    }

    add(element) {
        this.numbers.push(element);

        this.numbers.sort((a, b) => a - b);

        this.size++;
    }

    remove(index) {
        if (index >= 0 && index < this.numbers.length) {
            this.numbers.splice(index, 1);

            this.numbers.sort((a, b) => a - b);

            this.size--;
        }

    }

    get(index) {
        if (index >= 0 && index < this.numbers.length) {
            return this.numbers[index]
        }
    }
}

let myList = new List();
myList.add(5);
console.log(myList.get(0));
myList.add(3);
console.log(myList.get(0));
myList.remove(0);
console.log(myList.get(0));
console.log(myList.size);
