const { expect } = require('chai');
const { isOddOrEven } = require('./isOddOrEven');

describe('Odd or Even string length', () => {
    it('even string length', () => {
        expect(isOddOrEven('I am')).to.equal('even');
    });

    it('odd string length', () => {
        expect(isOddOrEven('off')).to.equal('odd')
    });

    it('input is not a string', () => {
        expect(isOddOrEven(5)).to.be.undefined;
    });
})