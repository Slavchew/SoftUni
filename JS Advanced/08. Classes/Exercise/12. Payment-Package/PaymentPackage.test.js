const { expect, assert } = require('chai');
const { PaymentPackage } = require('./PaymentPackage');

describe('Testing PaymentPackage Class functionality', () => {

    describe('Tests for the constructor', () => {
        
        it('constructor', () => {
            let instance = new PaymentPackage('Name', 100);
 
            assert.equal(instance._name, 'Name');
            assert.equal(instance._value, 100);
            assert.equal(instance._VAT, 20);
            assert.equal(instance._active, true);
        });
    })



    describe('Tests for the Name', () => {
        
        it('Should throw errow when the Name is a number', () => {
            expect(() => new PaymentPackage(123, 123)).to.throw('Name must be a non-empty string');
        });
 
        it('Should throw errow when the Name is an array', () => {
            expect(() => new PaymentPackage(['abc'], 123)).to.throw('Name must be a non-empty string');
        });

        it('Should throw errow when the Name is an boolean', () => {
            expect(() => new PaymentPackage(true, 123)).to.throw('Name must be a non-empty string');
        });
 
        it('Should throw errow when the Name is empty', () => {
            expect(() => new PaymentPackage('', 123)).to.throw('Name must be a non-empty string');
        });
 
        it('Should return the Name if the input is good', () => {
            expect(() => new PaymentPackage('abc', 123)).not.to.throw('Name must be a non-empty string');
        });
    });

    describe('Tests for the Value', () => {
 
        it('Should throw errow when the Value is a string', () => {
            expect(() => new PaymentPackage('abc', '123')).to.throw('Value must be a non-negative number');
        });
 
        it('Should throw errow when the Value is an array', () => {
            expect(() => new PaymentPackage('abc', [123])).to.throw('Value must be a non-negative number');
        });

        it('Should throw errow when the Value is an boolean', () => {
            expect(() => new PaymentPackage('abc', true)).to.throw('Value must be a non-negative number');
        });
 
        it('Should throw errow when the Value is negative', () => {
            expect(() => new PaymentPackage('abc', -125)).to.throw('Value must be a non-negative number');
        });
 
        it('Should return the Value if the input is good', () => {
            expect(() => new PaymentPackage('abc', 123)).not.to.throw('Value must be a non-negative number');
        });

        it('Set value to null', () => {
            let instance = new PaymentPackage('Name', 100);
            assert.doesNotThrow(() => { instance.value = 0 });
        });
    });

    describe('Tests for the VAT', () => {
        let flagClass = null;

        beforeEach(() => {
            flagClass = new PaymentPackage('abc', 123);
        });
 
        it('Should throw errow when the VAT is a string', () => {
            expect(() => flagClass.VAT = 'abc').to.throw('VAT must be a non-negative number');
        });
 
        it('Should throw errow when the VAT is an array', () => {
            expect(() => flagClass.VAT = [123]).to.throw('VAT must be a non-negative number');
        });

        it('Should throw errow when the VAT is an boolean', () => {
            expect(() => flagClass.VAT = true).to.throw('VAT must be a non-negative number');
        });
 
        it('Should throw errow when the VAT is negative', () => {
            expect(() => flagClass.VAT = -124).to.throw('VAT must be a non-negative number');
        });
 
        it('Should return the VAT if the input is good', () => {
            expect(() => flagClass.VAT = 124).not.to.throw('VAT must be a non-negative number');
        });
    });

    describe('Tests for the Active', () => {

        let flagClass = null;
        
        beforeEach(() => {
            flagClass = new PaymentPackage('abc', 123);
        });
 
        it('Should throw errow when the Active is a string', () => {
            expect(() => flagClass.active = 'abc').to.throw('Active status must be a boolean');
        });
 
        it('Should throw errow when the Active is an array', () => {
            expect(() => flagClass.active = [123]).to.throw('Active status must be a boolean');
        });

        it('Should throw errow when the Active is an number', () => {
            expect(() => flagClass.active = 123).to.throw('Active status must be a boolean');
        });
 
        it('Should throw errow when the Active is negative', () => {
            expect(() => flagClass.active = -124).to.throw('Active status must be a boolean');
        });
 
        it('Should return the VAT if the input is good', () => {
            expect(() => flagClass.active = true).not.to.throw('Active status must be a boolean');
        });
    });

    describe('Tests for toString Method', () => {

        let flagClass = null;
        
        beforeEach(() => {
            flagClass = new PaymentPackage('abc', 123);
        });

        it('Should return a string as all the input is correct - 1', () => {
            let output = [
                `Package: abc`,
                `- Value (excl. VAT): 123`,
                `- Value (VAT 20%): 147.6`
            ]
            expect(flagClass.toString()).to.equal(output.join('\n'));
        });
 
        it('Should return a string as all the input is correct - 2', () => {
            flagClass.VAT = 30;
            let output = [
                `Package: abc`,
                `- Value (excl. VAT): 123`,
                `- Value (VAT 30%): 159.9`
            ]
            expect(flagClass.toString()).to.equal(output.join('\n'));
        });
 
        it('Should return a string as all the input is correct - 3', () => {
            flagClass.active = false;
            let output = [
                `Package: abc (inactive)`,
                `- Value (excl. VAT): 123`,
                `- Value (VAT 20%): 147.6`
            ]
            expect(flagClass.toString()).to.equal(output.join('\n'));
        });
 
        it('Should return a string as all the input is correct - 4', () => {
            flagClass.VAT = 30;
            flagClass.active = false;
            let output = [
                `Package: abc (inactive)`,
                `- Value (excl. VAT): 123`,
                `- Value (VAT 30%): 159.9`
            ]
            expect(flagClass.toString()).to.equal(output.join('\n'));
        });
    });
});