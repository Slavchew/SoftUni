function fishTank(input) {
    let length = Number(input[0]);
    let width = Number(input[1]);
    let height = Number(input[2]);

    let volume = length * width * height;
    let litters = volume * 0.001;

    let percentage = Number(input[3]) * 0.01;

    let realLitters = litters * (1 - percentage);

    console.log(realLitters.toFixed(3));
}
fishTank(["85", "75", "47", "17"])