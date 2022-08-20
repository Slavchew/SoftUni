function solve() {
    const infoLabel = document.querySelector('#info span')
    const departBtn = document.getElementById('depart');
    const arriveBtn = document.getElementById('arrive');
    let stop = {
        next: 'depot'
    }

    async function depart() {
        departBtn.disabled = true;

        const res = await fetch(`http://localhost:3030/jsonstore/bus/schedule/${stop.next}`);
        stop = await res.json();

        infoLabel.textContent = `Next stop ${stop.name}`;

        arriveBtn.disabled = false;
    }

    function arrive() {
        infoLabel.textContent = `Arriving at ${stop.name}`

        departBtn.disabled = false;
        arriveBtn.disabled = true;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();