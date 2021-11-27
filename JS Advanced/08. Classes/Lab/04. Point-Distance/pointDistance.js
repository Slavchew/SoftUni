class Point {
    constructor(x, y) {
        this.x = x;
        this.y = y;
    }

    static distance(a, b) {
        let biggerX = Math.max(a.x, b.x);
        let lowerX = Math.min(a.x, b.x);

        let biggerY = Math.max(a.y, b.y);
        let lowerY = Math.min(a.y, b.y);

        let result = ((biggerX - lowerX) ** 2) + ((biggerY - lowerY) ** 2);

        return Math.sqrt(result);
    }
}

let p1 = new Point(5, 5);
let p2 = new Point(9, 8);
console.log(Point.distance(p1, p2));