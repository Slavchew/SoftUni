function getArticleGenerator(articles) {
    let arr = articles;

    let resultDiv = document.getElementById('content');
    return () => {
        if (arr.length != 0) {
            let article = document.createElement('article');
            article.textContent = arr.shift();
            resultDiv.appendChild(article);
        }
    }
}
