const { chromium, devices } = require('playwright-chromium');
const { expect } = require('chai');

const mockData = require('./mockData.json')

function json(data) {
    return {
        status: 200,
        headers: {
            'Access-Control-Allow-Origin': '*',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    }
}

let browser, page;

describe('Tests', async function () {
    this.timeout(60000);

    before(async () => { browser = await chromium.launch({ headless: false, slowMo: 3000 }); });
    after(async () => { await browser.close(); });
    beforeEach(async () => {
        page = await browser.newPage();
        await page.goto('http://localhost:5500');
    });
    afterEach(async () => { await page.close(); });

    it('loads and display all books', async () => {
        await page.route('**/jsonstore/collections/books*', (route) => {
            route.fulfill(json(mockData.books))
        });

        await page.click('text=Load All Books');

        await page.waitForSelector('text=Harry Potter');

        const rows = await page.$$eval('tr', (rows) => rows.map(r => r.textContent));

        expect(rows[1]).to.contains('Harry Potter');
        expect(rows[1]).to.contains('Rowling');
        expect(rows[2]).to.contains('C# Fundamentals');
        expect(rows[2]).to.contains('Nakov');
    });

    it('create book should work correctly', async () => {
        await page.fill('form#createForm >> input[name="title"]', 'Title');
        await page.fill('form#createForm >> input[name="author"]', 'Author');

        const [request] = await Promise.all([
            page.waitForRequest(req => req.method() === 'POST'),
            page.click('form#createForm >> text=Submit')
        ]);

		const data = JSON.parse(request.postData());

        expect(data.title).to.equal('Title');
        expect(data.author).to.equal('Author');
    });

    describe('Edit Tests', () => {
        it('loads edit form with correct data', async () => {
            await page.route('**/jsonstore/collections/books*', (route) => {
                route.fulfill(json(mockData.books))
            });
    
            await page.route('**/jsonstore/collections/books/d953e5fb-a585-4d6b-92d3-ee90697398a0', (route) => {
                route.fulfill(json(mockData.books['d953e5fb-a585-4d6b-92d3-ee90697398a0']))
            });
    
            await page.click('text=Load All Books');
            await page.waitForSelector('text=Harry Potter');
            await page.click('text=Edit');
    
            await page.waitForSelector('form#editForm');
            const titleValue = await page.inputValue('form#editForm >> input[name="title"]');
            const authorValue = await page.inputValue('form#editForm >> input[name="author"]');
    
            expect(titleValue).to.equal('Harry Potter and the Philosopher\'s Stone');
            expect(authorValue).to.equal('J.K.Rowling');
        });

        it('edit should work correctly', async () => {
            // Edit record
            await page.route('**/jsonstore/collections/books*', (route) => {
                route.fulfill(json(mockData.books))
            });
    
            await page.route('**/jsonstore/collections/books/d953e5fb-a585-4d6b-92d3-ee90697398a0', (route) => {
                route.fulfill(json(mockData.books['d953e5fb-a585-4d6b-92d3-ee90697398a0']))
            });
    
            await page.click('text=Load All Books');
            await page.waitForSelector('text=Harry Potter');
            await page.click('text=Edit');

            await page.fill('form#editForm >> input[name="title"]', 'Harry Potter 2');
            await page.fill('form#editForm >> input[name="author"]', 'J.K.R 111');
    
            const [request] = await Promise.all([
                page.waitForRequest(req => req.method() === 'PUT'),
                page.click('form#editForm >> text=Save')
            ]);
    
            const data = JSON.parse(request.postData());
    
            expect(data.title).to.equal('Harry Potter 2');
            expect(data.author).to.equal('J.K.R 111');
        })
    })

    it('delete book should work correctly', async () => {
        // Not working
        // Body data is null
        await page.route('**/jsonstore/collections/books*', (route) => {
            route.fulfill(json(mockData.books))
        });

        await page.click('text=Load All Books');
        await page.waitForSelector('text=Harry Potter');

        await page.once('dialog', async dialog => {
			await dialog.accept()
		})

        const [request] = await Promise.all([
            page.waitForRequest(req => req.method() === 'DELETE'),
            page.click('text=Delete'),
        ]);

        const data = JSON.parse(request.postData());

        expect(data.title).to.equal('Harry Potter and the Philosopher\'s Stone');
        expect(data.author).to.equal('J.K.Rowling');
    });
});