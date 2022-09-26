class Box {
    constructor() {
        this.elements = [];
    }
    add(element) {
        this.elements.push(element);
    }
    remove() {
        this.elements.pop();
    }
    get count() {
        return this.elements.length;
    }
}
let box = new Box();
box.add("Pesho");
box.add("Gosho");
console.log(box.count);
box.remove();
console.log(box.count);
