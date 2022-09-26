abstract class Melon {
    private _elementIndex: number;
    
    public weight: number;
    public melonSort: string;    

    constructor(weight, melonSort) {
        this.weight = weight;
        this.melonSort = melonSort;

        this._elementIndex = this.weight * this.melonSort.length;
    }

    public get elementIndex() {
        return this._elementIndex;
    }

    toString() : string {
        return `
Element: ${this.constructor.name}
Sort: ${this.melonSort}
Element Index: ${this.elementIndex}`
    }
}

class Watermelon extends Melon {
    constructor(weight, melonSort) {
        super(weight, melonSort);
    }
}

class Firemelon extends Melon {
    constructor(weight, melonSort) {
        super(weight, melonSort);
    }
}

class Earthmelon extends Melon {
    constructor(weight, melonSort) {
        super(weight, melonSort);
    }
}

class Airmelon extends Melon {
    constructor(weight, melonSort) {
        super(weight, melonSort);
    }
}

class Melolemonmelon extends Melon {
    private elements: Array<string>;
    public element: string;

    constructor(weight, melonSort) {
        super(weight, melonSort);

        this.elements = ['Water', 'Fire', 'Earth', 'Air'];

        this.morph();
    }

    morph() {
        this.element = this.elements.shift()!;
        this.elements.push(this.element);
    }

    toString() : string {
        return `
Element: ${this.element}
Sort: ${this.melonSort}
Element Index: ${this.elementIndex}`
    }
}


let watermelon : Melolemonmelon = new Melolemonmelon(12.5, "Kingsize");
console.log(watermelon.toString());

watermelon.morph();
console.log(watermelon.toString());

watermelon.morph();
console.log(watermelon.toString());

watermelon.morph();
console.log(watermelon.toString());

watermelon.morph();
console.log(watermelon.toString());


// Element: Water
// Sort: Kingsize
// Element Index: 100
