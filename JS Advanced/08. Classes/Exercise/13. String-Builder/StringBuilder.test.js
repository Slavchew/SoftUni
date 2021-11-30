const { expect, assert } = require('chai');
const { StringBuilder } = require('./StringBuilder');

describe('Testing StringBuilder Class functionality', () => {

    describe('Tests for the constructor', () => {

        it('Should return array with string symbols', () => {
            let instance = new StringBuilder('abc');

            assert.deepEqual(instance._stringArray, ['a', 'b', 'c']);
        });

        it('Should return empty array when input is undefined', () => {
            let instance = new StringBuilder(undefined);

            expect(instance._stringArray).to.be.empty;
        });

        it('Should throw error when input is number', () => {
            expect(() => new StringBuilder(123)).to.throw('Argument must be a string');
        });

        it('Should throw error when input is array', () => {
            expect(() => new StringBuilder([123])).to.throw('Argument must be a string');
        });

        it('Should throw error when input is array', () => {
            expect(() => new StringBuilder('abc')).not.to.throw('Argument must be a string');
        });
    });

    describe('Tests for Append method', () => {

        let instance = null;

        beforeEach(() => {
            instance = new StringBuilder('abc');
        });

        it('Should append input to stringArray property', () => {
            instance.append('def');

            assert.deepEqual(instance._stringArray, ['a', 'b', 'c', 'd', 'e', 'f']);
        });

        it('Should append input to stringArray property', () => {
            instance.append('abc');

            assert.deepEqual(instance._stringArray, ['a', 'b', 'c', 'a', 'b', 'c']);
        });
    });

    describe('Tests for Prepend method', () => {

        let instance = null;

        beforeEach(() => {
            instance = new StringBuilder('abc');
        });

        it('Should prepend input to stringArray property', () => {
            instance.prepend('def');

            assert.deepEqual(instance._stringArray, ['d', 'e', 'f', 'a', 'b', 'c']);
        });

        it('Should prepend input to stringArray property', () => {
            instance.prepend('abc');

            assert.deepEqual(instance._stringArray, ['a', 'b', 'c', 'a', 'b', 'c']);
        });
    });

    describe('Tests for InsertAt method', () => {

        let instance = null;

        beforeEach(() => {
            instance = new StringBuilder('abc');
        });

        it('Should insertAt input to stringArray property', () => {
            instance.insertAt('def', 1);

            assert.deepEqual(instance._stringArray, ['a', 'd', 'e', 'f', 'b', 'c']);
        });

        it('Should insertAt input to stringArray property', () => {
            instance.insertAt('abc', 2);

            assert.deepEqual(instance._stringArray, ['a', 'b', 'a', 'b', 'c', 'c']);
        });
    });

    describe('Tests for Remove method', () => {

        let instance = null;

        beforeEach(() => {
            instance = new StringBuilder('abcdef');
        });

        it('Should remove input to stringArray property', () => {
            instance.remove(1, 2);

            assert.deepEqual(instance._stringArray, ['a', 'd', 'e', 'f']);
        });

        it('Should remove input to stringArray property', () => {
            instance.remove(2, 3);

            assert.deepEqual(instance._stringArray, ['a', 'b', 'f']);
        });

        it('Should remove input to stringArray property', () => {
            instance.remove(1, 0);

            assert.deepEqual(instance._stringArray, ['a', 'b', 'c', 'd', 'e', 'f']);
        });

        it('Should remove input to stringArray property', () => {
            instance.remove(-3, 2);

            assert.deepEqual(instance._stringArray, ['a', 'b', 'c', 'f']);
        });

        it('Should remove input to stringArray property', () => {
            instance.remove(0, 5);

            assert.deepEqual(instance._stringArray, ['f']);
        });
    });

    describe('Tests for ToString method', () => {

        it('Should return stringArray property concated', () => {

            let instance = new StringBuilder('WindWaterFire');

            assert.equal(instance.toString(), 'WindWaterFire');
        });

        it('Should insertAt input to stringArray property', () => {
            let instance = new StringBuilder('Abcdssss');

            assert.equal(instance.toString(), 'Abcdssss');
        });
    });

    describe('Tests for Verify Method', () => {

        let instance = null;

        beforeEach(() => {
            instance = new StringBuilder('abc');
        });

        it('Should throw error when input is number', () => {
            expect(() => StringBuilder._vrfyParam(123)).to.throw('Argument must be a string');
        });

        it('Should throw error when input is array', () => {
            expect(() => StringBuilder._vrfyParam([123])).to.throw('Argument must be a string');
        });

        it('Should throw error when input is boolean', () => {
            expect(() => StringBuilder._vrfyParam(true)).to.throw('Argument must be a string');
        });
    })
});