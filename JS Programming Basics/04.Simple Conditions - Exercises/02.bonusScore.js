function bonusScore(input) {
    let startPoints = Number(input[0]);

    let bonusPoints = 0;

    if (startPoints <= 100) {
        bonusPoints += 5;
    }
    else if (startPoints > 100 && startPoints <= 1000) {
        bonusPoints += startPoints * 0.20;
    }
    else if (startPoints > 1000) {
        bonusPoints += startPoints * 0.10;
    }

    if (startPoints % 2 === 0) {
        bonusPoints++;
    }
    else if (startPoints % 10 === 5) {
        bonusPoints += 2;
    }

    console.log(bonusPoints);
    console.log(startPoints + bonusPoints);
}
bonusScore(["175"])