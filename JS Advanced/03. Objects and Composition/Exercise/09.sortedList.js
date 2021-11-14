function createSortedList() {
    return {
        numbers: [],
        add(num) {
            this.numbers.push(num);
            this.numbers.sort((a, b) => a - b);
            this.size++;
        },
        remove(index) {
            if (index >= 0 && index < this.numbers.length) {
                this.numbers.splice(index, 1);
                this.size--
            }
        },
        get(index) {
            if (index >= 0 && index < this.numbers.length) {
                return this.numbers[index];
            }
        },
        size: 0
    }

}

let list = createSortedList();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1));
list.remove(1);
console.log(list.get(1));
console.log(list.size)

