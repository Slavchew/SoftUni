function result() {
    
    class Figure {
        constructor(unit = 'cm') {
            this.units = unit;
        }

        get area() {
            return null;
        }

        changeUnits(unit) {
            this.units = unit;
        }

        toString() {
            return `Figures units: ${this.units}`;
        }
    }

    class Circle extends Figure {
        constructor(radius, unit) {
            super(unit);
            this.radius = radius;
        }

        get area() {
            if (this.units === 'cm') {
                return this.radius ** 2 * Math.PI;
            } else if (this.units === 'mm') {
                return this.radius ** 2 * Math.PI * 100;
            } else if (this.units === 'm') {
                return this.radius ** 2 * Math.PI / 100;
            }
        }

        changeUnits(unit) {
            this.units = unit;
        }

        toString() {
            if (this.units === 'cm') {
                return super.toString() + ` Area: ${this.area} - radius: ${this.radius}`;
            } else if (this.units === 'mm') {
                return super.toString() + ` Area: ${this.area} - radius: ${this.radius * 10}`;
            } else if (this.units === 'm') {
                return super.toString() + ` Area: ${this.area} - radius: ${this.radius / 10}`;
            }
        }
    }

    class Rectangle extends Figure {
        constructor(width, height, unit) {
            super(unit);
            this.width = width;
            this.height = height;
        }

        get area() {
            if (this.units === 'cm') {
                return this.width * this.height;
            } else if (this.units === 'mm') {
                return this.width * this.height * 100;
            } else if (this.units === 'm') {
                return this.width * this.height / 100;
            }
        }

        changeUnits(unit) {
            this.units = unit;
        }

        toString() {
            if (this.units === 'cm') {
                return super.toString() + ` Area: ${this.area} - width: ${this.width}, height: ${this.height}`;
            } else if (this.units === 'mm') {
                return super.toString() + ` Area: ${this.area} - width: ${this.width * 10}, height: ${this.height * 10}`;
            } else if (this.units === 'm') {
                return super.toString() + ` Area: ${this.area} - width: ${this.width * 10}, height: ${this.height * 10}`;
            }
        }
    }

    return {
        Figure,
        Circle,
        Rectangle
    }
}


let classes = result();
let Figure = classes.Figure;
let Rectangle = classes.Rectangle;
let Circle = classes.Circle;

let c = new Circle(5);
console.log(c.area); // 78.53981633974483
console.log(c.toString()); // Figures units: cm Area: 78.53981633974483 - radius: 5

let r = new Rectangle(3, 4, 'mm');
console.log(r.area); // 1200 
console.log(r.toString()); //Figures units: mm Area: 1200 - width: 30, height: 40

r.changeUnits('cm');
console.log(r.area); // 12
console.log(r.toString()); // Figures units: cm Area: 12 - width: 3, height: 4

c.changeUnits('mm');
console.log(c.area); // 7853.981633974483
console.log(c.toString()) // Figures units: mm Area: 7853.981633974483 - radius: 50
