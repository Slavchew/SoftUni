const { expect } = require('chai');
const { lookupChar } = require('./charLookUp');

describe('Char Indexer', () => {
    it('should return char at given index', () => {
        expect(lookupChar('correct types', 4)).to.equal('e');
    });

    it('should give error if index is bigger than string length', () => {
        expect(lookupChar('correct types', 55)).to.equal('Incorrect index');
    });

    it('should give error if index is equal to string length', () => {
        expect(lookupChar('correct', 7)).to.equal('Incorrect index');
    });

    it('should give error if index is negative', () => {
        expect(lookupChar('correct types', -5)).to.equal('Incorrect index');
    });

    it('should give error if index is not a number', () => {
        expect(lookupChar('correct types', '5')).to.be.undefined;
    });

    it('should give error if index is a floating-point number', () => {
        expect(lookupChar('correct types', 2.22)).to.be.undefined;
    });

    it('should give error if text is not a string', () => {
        expect(lookupChar(125, 1)).to.be.undefined;
    });

    it('should give error if parameters is not valid', () => {
        expect(lookupChar(125, '2')).to.be.undefined;
    });
})