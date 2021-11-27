const { expect } = require('chai');
const { mathEnforcer } = require('./mathEnforcer');

describe('math Enforcer', () => {
    describe('addFive', () => {
        it('should return number plus 5', () => {
            expect(mathEnforcer.addFive(3)).to.equal(8);
            expect(mathEnforcer.addFive(0)).to.equal(5);
            expect(mathEnforcer.addFive(-3)).to.equal(2);
        });

        it('should return error if parameter is non-number', () => {
            expect(mathEnforcer.addFive('4')).to.be.undefined;
        });

        it('should return number plus 5', () => {
            expect(mathEnforcer.addFive(1.55)).to.closeTo(6.55, 0.01);
        });
    });

    describe('subtractTen', () => {
        it('should return number minus 10', () => {
            expect(mathEnforcer.subtractTen(3)).to.equal(-7);
            expect(mathEnforcer.subtractTen(0)).to.equal(-10);
            expect(mathEnforcer.subtractTen(-5)).to.equal(-15);
        });

        it('should return error if parameter is non-number', () => {
            expect(mathEnforcer.subtractTen('4')).to.be.undefined;
        });

        it('should return number minus 10', () => {
            expect(mathEnforcer.subtractTen(1.55)).to.closeTo(-8.45, 0.01);
        });
    });

    describe('sum', () => {
        it('should return sum of two numbers', () => {
            expect(mathEnforcer.sum(3, 9)).to.equal(12);
            expect(mathEnforcer.sum(0,7)).to.equal(7);
        });

        it('should return error if one of parameter is non-number', () => {
            expect(mathEnforcer.sum('4', 5)).to.be.undefined;
            expect(mathEnforcer.sum(4, '5')).to.be.undefined;
            expect(mathEnforcer.sum('4', '5')).to.be.undefined;
        });

        it('should return sum of two floating-point numbers', () => {
            expect(mathEnforcer.sum(1.55, 2.55)).to.closeTo(4.10, 0.01);
        });
    });
});