const { expect } = require('chai');
const { createCalculator } = require('./addSubtract');

describe('Summator', () => {
    let instance = null;

    beforeEach(() => {
        instance = createCalculator();
    })

    it('has all methods', () => {
        expect(instance).to.has.ownProperty('add');
        expect(instance).to.has.ownProperty('subtract');
        expect(instance).to.has.ownProperty('get');
    });

    it('adds single numbers', () => {
        instance.add(1);
        expect(instance.get()).to.equal(1);
    });

    it('adds multiple numbers', () => {
        instance.add(1);
        instance.add(2);
        expect(instance.get()).to.equal(3);
    });

    it('adds numbers as strings', () => {
        instance.add('1');
        expect(instance.get()).to.equal(1);
    });

    it('adds multiple numbers as strings', () => {
        instance.add('1');
        instance.add('2');
        expect(instance.get()).to.equal(3);
    });

    it('subtracts single numbers', () => {
        instance.subtract(1);
        expect(instance.get()).to.equal(-1);
    });

    it('subtracts multiple numbers', () => {
        instance.subtract(1);
        instance.subtract(2);
        expect(instance.get()).to.equal(-3);
    });

    it('subtracts numbers as strings', () => {
        instance.subtract('1');
        expect(instance.get()).to.equal(-1);
    });

    it('subtracts multiple numbers as strings', () => {
        instance.subtract('1');
        instance.subtract('2');
        expect(instance.get()).to.equal(-3);
    });

    it('add and subtract numbers', () => {
        instance.add(7);
        instance.subtract(2);
        expect(instance.get()).to.equal(5);
    });

    it('add and subtract numbers', () => {
        instance.add(2);
        instance.subtract(8);
        expect(instance.get()).to.equal(-6);
    });

    it('add and subtract numbers as strings', () => {
        instance.add('7');
        instance.subtract('2');
        expect(instance.get()).to.equal(5);
    });

    it('add and subtract numbers as strings', () => {
        instance.add('2');
        instance.subtract('8');
        expect(instance.get()).to.equal(-6);
    });

    it('do not add and subtract numbers', () => {
        instance.add(0);
        instance.subtract(0);
        expect(instance.get()).to.equal(0);
    });

    it('test get method', () => {
        expect(instance.get()).to.equal(0);
    });
});