function attachEventsListeners() {
    let buttons = Array.from(document.querySelectorAll("input[value=Convert]"));

    for (const button of buttons) {
        button.addEventListener('click', onClick)
    }

    let daysOutput = document.getElementById('days');
    let hoursOutput = document.getElementById('hours');
    let minutesOutput = document.getElementById('minutes');
    let secondsOutput = document.getElementById('seconds');


    function onClick(ev) {
        let div = ev.target.parentNode;
        let type = div.querySelector('label').textContent.slice(0, -2);
        let text = div.querySelector('input[type=text]').value;

        let days = 0;
        let hours = 0;
        let minutes = 0;
        let seconds = 0;

        if (type == 'Days') {
            days = Number(text);
            hours = days * 24;
            minutes = hours * 60;
            seconds = minutes * 60;
        } else if (type == 'Hours') {
            hours = Number(text);
            days = hours / 24;
            minutes = hours * 60;
            seconds = minutes * 60;
        } else if (type == 'Minutes') {
            minutes = Number(text);
            hours = minutes / 60;
            days = hours / 24;
            seconds = minutes * 60;
        } else if (type == 'Seconds') {
            seconds = Number(text);
            minutes = seconds / 60;
            hours = minutes / 60;
            days = hours / 24;
        }

        daysOutput.value = days;
        hoursOutput.value = hours;
        minutesOutput.value = minutes;
        secondsOutput.value = seconds;
    }
}