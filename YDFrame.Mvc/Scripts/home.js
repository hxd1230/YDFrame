function parseDate(date) {
    var newTime = new Date(parseInt(date.slice(6, 19)));
    var newYear = newTime.getFullYear();
    var newMonth = newTime.getMonth() + 1;
    var newDate = newTime.getDate();
    var second = newTime.getSeconds();
    var hour = newTime.getHours();
    hour = hour.toString().length == 1 ? "0" + hour : hour;
    var minute = newTime.getMinutes();
    second = second.toString().length == 1 ? "0" + second : second;
    minute = minute.toString().length == 1 ? "0" + minute : minute;
    var dateTime = newYear + "-" + newMonth + "-" + newDate + " " + hour + ":" + minute + ":" + second;
    return dateTime;
}