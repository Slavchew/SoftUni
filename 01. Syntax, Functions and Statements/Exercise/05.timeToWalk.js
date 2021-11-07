function solve(steps, footprint, speed) {
    const distance = steps * footprint;
    let time = Math.round(distance / speed * 3.6);
    time += Math.floor(distance / 500) * 60;

    const seconds = time % 60;
    time -= seconds;
    const minutes = (time / 60) % 60;
    time -= minutes * 60;
    const hours = time / 3600;

    console.log(`${pad(hours)}:${pad(minutes)}:${pad(seconds)}`);

    function pad(num) {
        return ('0' + num).slice(-2);
    }
}

solve(4000, 0.60, 5)