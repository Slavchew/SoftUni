const {expect} = require('chai');
const sum = require('./sumNumbers');

describe('Summator', () => {
    it('sum numbers from array', () => {
        expect(sum([1,2,3])).to.equal(6);
    });

    it('sum numbers from array as strings', () => {
        expect(sum(['1','2','3'])).to.equal(6);
    });
})