class Hex {
    constructor(number) {
        this.number = number;
    }

    toString() {
        const hexString = this.number.toString(16);
        return `0x${hexString.toUpperCase()}`;
    }

    valueOf() {
        return this.number;
    }

    plus(num) {
        return new Hex(this.number + num);
    }

    minus(num) {
        return new Hex(this.number - num);
    }

    parse(hex) {
        return parseInt(hex, 16);
    }
}

let FF = new Hex(255);
console.log(FF.toString());
FF.valueOf() + 1 == 256;
let a = new Hex(10);
let b = new Hex(5);
console.log(a.plus(b).toString());
console.log(a.plus(b).toString()==='0xF');
console.log(FF.parse('AAA'));
