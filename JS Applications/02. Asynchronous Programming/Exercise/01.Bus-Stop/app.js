function getInfo() {
    const stopId = document.getElementById('stopId');
    const ul = document.getElementById('buses');
    const stopNameElement = document.getElementById('stopName');

    fetch(`http://localhost:3030/jsonstore/bus/businfo/${stopId.value}`)
        .then(res => {
            console.log(res);
            if (res.status != 200 || stopId == '') {
                throw new Error('Stop ID not found');
            }
            return res.json();
        }).then(HandleBuses)
        .catch(HandleError);

    /* Using Async/Await

    try {
        const res = await fetch(`http://localhost:3030/jsonstore/bus/businfo/${stopId}`);
        if (res.status != 200 || stopId == '') {
            throw new Error('Error');
        }
        const data = await res.json();
        HandleBuses(data);

    } catch (error) {
        HandleError(error);
    }

    */

    function HandleBuses(data) {
        stopNameElement.textContent = data.name;

        ul.textContent = '';
        for (const [busId, time] of Object.entries(data.buses)) {
            let li = document.createElement('li');
            li.textContent = `Bus ${busId} arrives in ${time} minutes`

            ul.appendChild(li);
        }
    }

    function HandleError(error) {
        stopNameElement.textContent = 'Error';
        ul.textContent = '';
    }
}