function previousDay(year, month, day) {
    
    const today = new Date(year, month, day)
    const yesterday = new Date(today)

    console.log(yesterday.setDate(yesterday.getDate() - 1));
}

previousDay(2016, 9, 30)