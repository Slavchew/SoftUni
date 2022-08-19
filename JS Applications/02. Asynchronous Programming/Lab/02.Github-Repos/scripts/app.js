function loadRepos() {
    const username = document.getElementById('username').value;
    const ul = document.getElementById('repos');

	fetch(`https://api.github.com/users/${username}/repos`)
        .then(res => {
            if (!res.ok) {
                throw new Error(`${res.status} (${res.statusText})`);
            }
            return res.json();
        })
        .then(HandleRepos)
        .catch(HandleError);

    function HandleRepos(data){
        ul.innerHTML = '';
        for (const repo of data) {
            let li = document.createElement('li');
            let a = document.createElement('a');
            a.href = repo.html_url;
            a.text = repo.full_name;

            li.appendChild(a);
            ul.appendChild(li);
        }
    }

    function HandleError(error) {
        ul.innerHTML = '';
        let li = document.createElement('li');
        li.textContent = error.message;
        ul.appendChild(li);
    }
}