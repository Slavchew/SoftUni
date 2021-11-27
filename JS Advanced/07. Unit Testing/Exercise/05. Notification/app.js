function notify(message) {
	const resultDiv = document.getElementById('notification');

	resultDiv.textContent = message;
	resultDiv.style.display = 'block';

	resultDiv.addEventListener('click', () => {
		resultDiv.style.display = 'none'
	})
}