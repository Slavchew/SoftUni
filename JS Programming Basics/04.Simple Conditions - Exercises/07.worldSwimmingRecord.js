function worldSwimmingRecord(input) {

    let recordInSeconds = Number(input[0]);
    let distanceInMeters = Number(input[1]);
    let timeInSecondsForMeter = Number(input[2]);

    let distanceInSeconds = distanceInMeters * timeInSecondsForMeter;
    let slowdown = (Math.floor(distanceInMeters / 15)) * 12.5;

    let timeToFinish = distanceInSeconds + slowdown;

    if (timeToFinish < recordInSeconds) {
        console.log(`Yes, he succeeded! The new world record is ${timeToFinish.toFixed(2)} seconds.`);
    } else {
        console.log(`No, he failed! He was ${(timeToFinish - recordInSeconds).toFixed(2)} seconds slower.`);
    }

}
worldSwimmingRecord(["55555.67",
"3017",
"5.03"])
