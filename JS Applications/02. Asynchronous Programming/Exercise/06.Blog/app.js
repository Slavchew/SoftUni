const postsDropDown = document.getElementById('posts');

function attachEvents() {
    const loadPostsBtn = document.getElementById('btnLoadPosts');
    const viewPostCommentsBtn = document.getElementById('btnViewPost');
    const postComments = document.getElementById('post-comments');

    loadPostsBtn.addEventListener('click', getAllPosts);

    viewPostCommentsBtn.addEventListener('click', async function () {
        const postId = postsDropDown.options[postsDropDown.selectedIndex].value;
        try {
            const [postData, postCommentsData] = await Promise.all([
                getPostById(postId),
                getCommentsByPostId(postId)
            ]);
            
            document.getElementById('post-title').textContent = postData.title;
            document.getElementById('post-body').textContent = postData.body;
    
            postComments.innerHTML = '';
            for (const {text} of postCommentsData) {
                const commentLiItem = document.createElement('li');
                commentLiItem.textContent = text;
    
                postComments.appendChild(commentLiItem);
            }
        } catch (error) {
            alert(error.message);
        }
    });
}

attachEvents();

async function getAllPosts() {
    const postsRes = await fetch('http://localhost:3030/jsonstore/blog/posts');
    const postsData = await postsRes.json();

    postsDropDown.innerHTML = '';
    for (const { id, title } of Object.values(postsData)) {
        const postOption = document.createElement('option');
        postOption.value = id;
        postOption.text = title;

        postsDropDown.appendChild(postOption);
    }
}

async function getCommentsByPostId(postId) {
    const commentsRes = await fetch('http://localhost:3030/jsonstore/blog/comments');
    const commentsData = await commentsRes.json();

    return Object.values(commentsData).filter(x => x.postId == postId);
}

async function getPostById(postId) {
    const postRes = await fetch(`http://localhost:3030/jsonstore/blog/posts/${postId}`);
    if (postRes.status != 200) {
        throw new Error('Post with the given id does not exists');
    }
    const postData = await postRes.json();

    return postData;
}
