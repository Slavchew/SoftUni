class Box<T> {
    private elements: Array<T>;

    constructor() {
        this.elements = [];
    }

    add(element : T) {
        this.elements.push(element);
    }

    remove() {
        this.elements.pop();
    }

    get count(): number {
        return this.elements.length;
    }
}

let box = new Box<String>();
box.add("Pesho");
box.add("Gosho");
console.log(box.count);
box.remove();
console.log(box.count);