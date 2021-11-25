const { expect } = require('chai');
const rgbToHexColor = require('./rgbToHex');

describe('RGB Convertor', () => {
    describe('Happy path', () => {
        it('converts white', () => {
            expect(rgbToHexColor(255, 255, 255)).to.equal('#FFFFFF');
        });
    
        it('converts black', () => {
            expect(rgbToHexColor(0, 0, 0)).to.equal('#000000');
        });
    
        it('convert Lilac Bush to #A27DD8', () => {
            expect(rgbToHexColor(162, 125, 216)).to.equal('#A27DD8');
        });
    });

    describe('Invalid parameter', () => {
        it('parameter is not in range', () => {
            expect(rgbToHexColor(0, 0, 288)).to.be.undefined;
        });
    
        it('parameter is not in range', () => {
            expect(rgbToHexColor(-2, 0, 0)).to.be.undefined;
        });
    
        it('parameter is invalid type', () => {
            expect(rgbToHexColor(0, 255, '0')).to.be.undefined;
        });
    });
});