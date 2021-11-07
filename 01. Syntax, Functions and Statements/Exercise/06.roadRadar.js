function roadRadar(speed, area) {
    let overLimit = 0;
    let speedLimit = 0;

    switch (area) {
        case 'motorway':
            speedLimit = 130;
            overLimit = speed - speedLimit;
            break;
        case 'interstate':
            speedLimit = 90;
            overLimit = speed - speedLimit;
            break;
        case 'city':
            speedLimit = 50;
            overLimit = speed - speedLimit;
            break;
        case 'residential':
            speedLimit = 20;
            overLimit = speed - speedLimit;
            break;
    }

    if (overLimit > 40) {
        console.log(`The speed is ${overLimit} km/h faster than the allowed speed of ${speedLimit} - reckless driving`)
    } else if (overLimit > 20) {
        console.log(`The speed is ${overLimit} km/h faster than the allowed speed of ${speedLimit} - excessive speeding`)
    } else if (overLimit > 0) {
        console.log(`The speed is ${overLimit} km/h faster than the allowed speed of ${speedLimit} - speeding`)
    } else {
        console.log(`Driving ${speed} km/h in a ${speedLimit} zone`);
    }
}

roadRadar(200, 'motorway')