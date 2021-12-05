const { expect } = require('chai');
const { testNumbers } = require('./testNumbers');

describe('Tests …', () => {
    describe('Sum Method', () => {
        it('Should return undefined if parameters are strings', () => {
            expect(testNumbers.sumNumbers('2', 3)).to.be.undefined;
            expect(testNumbers.sumNumbers(2, '3')).to.be.undefined;
            expect(testNumbers.sumNumbers('2', '3')).to.be.undefined;
        });
        it('Should return undefined if parameters are arrays', () => {
            expect(testNumbers.sumNumbers([2], 3)).to.be.undefined;
            expect(testNumbers.sumNumbers(2, [3])).to.be.undefined;
            expect(testNumbers.sumNumbers([2], [3])).to.be.undefined;
        });
        it('Should return undefined if parameters are boolean', () => {
            expect(testNumbers.sumNumbers('2', true)).to.be.undefined;
            expect(testNumbers.sumNumbers(false, '3')).to.be.undefined;
            expect(testNumbers.sumNumbers(true, false)).to.be.undefined;
        });

        it('Should return sum of the given numbers rounded to second digit after decimal point', () => {
            expect(testNumbers.sumNumbers(2, 3)).to.equal('5.00');
            expect(testNumbers.sumNumbers(2.127, 3)).to.equal('5.13');
            expect(testNumbers.sumNumbers(2, 3.559)).to.equal('5.56');
            expect(testNumbers.sumNumbers(3.499, 3)).to.equal('6.50');
        });
    });

    describe('Check Method', () => {
        it('Should throw error if parameter is string', () => {
            expect(() => testNumbers.numberChecker('text')).to.throw('The input is not a number!');
        });
        it('Should throw error if parameter is undefined', () => {
            expect(() => testNumbers.numberChecker(undefined)).to.throw('The input is not a number!');
        });

        it('Should return \'The number is even!\' if parameter is even number', () => {
            expect(testNumbers.numberChecker(2)).to.equal('The number is even!');
            expect(testNumbers.numberChecker(6)).to.equal('The number is even!');
            expect(testNumbers.numberChecker(-24)).to.equal('The number is even!');
            expect(testNumbers.numberChecker(100)).to.equal('The number is even!');
            expect(testNumbers.numberChecker(0)).to.equal('The number is even!');
        });

        it('Should return \'The number is odd!\' if parameter is odd number', () => {
            expect(testNumbers.numberChecker(1)).to.equal('The number is odd!');
            expect(testNumbers.numberChecker(3)).to.equal('The number is odd!');
            expect(testNumbers.numberChecker(21)).to.equal('The number is odd!');
            expect(testNumbers.numberChecker(99)).to.equal('The number is odd!');
            expect(testNumbers.numberChecker(-5)).to.equal('The number is odd!');
        });
    });

    describe('Average Method', () => {
        it('Should return average sum of the array that comes as parameter', () => {
            expect(testNumbers.averageSumArray([1,2,3,4,5])).to.equal(3.00);
            expect(testNumbers.averageSumArray([-5,2,7,15,8])).to.equal(5.40);
            expect(Number(testNumbers.averageSumArray([-66,25,31,-14,5.2]).toFixed(2))).to.equal(-3.76);
            expect(Number(testNumbers.averageSumArray([2.5,-8.52,0.2,-0.85,-5]).toFixed(3))).to.equal(-2.334);
        });
    });
});
