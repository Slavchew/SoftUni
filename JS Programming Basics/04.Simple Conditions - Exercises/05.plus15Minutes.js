function plus15Minutes(input) {
    let hours = Number(input[0]);
    let minutes = Number(input[1]);

    minutes += 15;

    if (minutes == 60) {
        minutes -= 60;
        hours++;
    }

    if (hours >= 24) {
        hours = 0;
    }

    if (minutes < 10) {
        console.log(`${hours}:0${minutes}`);
    }
    else{
        console.log(`${hours}:${minutes}`);
    }
}
plus15Minutes(["23", "59"])