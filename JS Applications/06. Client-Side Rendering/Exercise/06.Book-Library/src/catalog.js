import { html } from './utility.js';

const catalogTemplate = (books) => html`
<table>
    <thead>
        <tr>
            <th>Title</th>
            <th>Author</th>
            <th>Action</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>Harry Potter</td>
            <td>J. K. Rowling</td>
            <td>
                <button>Edit</button>
                <button>Delete</button>
            </td>
        </tr>
        <tr>
            <td>Game of Thrones</td>
            <td>George R. R. Martin</td>
            <td>
                <button>Edit</button>
                <button>Delete</button>
            </td>
        </tr>
    </tbody>
</table>`;


export function showCatalog(ctx) {
    ctx.render(catalogTemplate);
}