const { chromium } = require('playwright-chromium');
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

let browser, page; // Declare reusable variables

describe('E2E tests', async function () {
	this.timeout(60000);

	before(async () => { browser = await chromium.launch({ headless: false, slowMo: 5000 }); });
	after(async () => { await browser.close(); });
	beforeEach(async () => {
		page = await browser.newPage();
		await page.goto('http://localhost:5500');
	});
	afterEach(async () => { await page.close(); });

	it('load post on pressing refresh button', async () => {
		await page.route(
			'http://localhost:3030/jsonstore/messenger',
			request => request.fulfill(json(mockData.messages))
		);

		await page.waitForSelector('#messages');

		const [response] = await Promise.all([
			page.waitForResponse(r => r.request().url()
				.includes('/jsonstore/messenger') && r.request().method() === 'GET'),
			page.click('#refresh')
		]);

		const responseData = await response.json();

		expect(responseData).to.deep.eq(mockData.messages);
	});

	it('testing message form sumbit', async () => {
		await page.waitForSelector('#controls');
		await page.route(
			'http://localhost:3030/jsonstore/messenger',
			request => request.fulfill(json({ author: 'Andy', content: 'Hi from me!' }))
		);

		await page.fill('#author', 'Andy');
		await page.fill('#content', 'Hi from me!');

		const [response] = await Promise.all([
			page.waitForRequest(r => r.url()
				.includes('/jsonstore/messenger') &&
				r.method() === 'POST'),
			page.click('#submit')
		]);

		const responseData = JSON.parse(await response.postData())

		expect(responseData).to.deep.eq({ author: 'Andy', content: 'Hi from me!' });
	});
});