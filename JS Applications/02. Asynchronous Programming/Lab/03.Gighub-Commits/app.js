function loadCommits() {
    const username = document.getElementById('username').value;
    const repoName = document.getElementById('repo').value;

    const ul = document.getElementById('commits');

    fetch(`https://api.github.com/repos/${username}/${repoName}/commits`)
        .then(res => {
            if (!res.ok) {
                throw new Error(`${res.status} (${res.statusText})`);
            }
            return res.json();
        })
        .then(HandleCommits)
        .catch(HandleError);
        

    function HandleCommits(data) {
        ul.innerHTML = '';
        for (const commit of data) {
            let li = document.createElement('li');
            li.textContent = `${commit.commit.author.name}: ${commit.commit.message}`

            ul.appendChild(li);
        }
    }

    function HandleError(error) {
        ul.innerHTML = '';
        let li = document.createElement('li');
        li.textContent = `${error.message}`;
        ul.appendChild(li);
    }
}