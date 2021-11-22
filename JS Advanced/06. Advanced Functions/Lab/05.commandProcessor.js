function solution() {
    let state = '';


    return {
        append,
        removeStart,
        removeEnd,
        print
    }
    function append(str) {
        state += str;
    }

    function removeStart(n) {
        state = state.slice(n);
    }

    function removeEnd(n) {
        state = state.slice(0, -n);
    }

    function print() {
        console.log(state);
    }
}
let firstZeroTest = solution();
firstZeroTest.append('hello');
firstZeroTest.append('again');
firstZeroTest.removeStart(3);
firstZeroTest.removeEnd(4);
firstZeroTest.print();
