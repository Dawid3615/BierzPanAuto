/* LAST UPDATE START */
function makeArray() {
    for (i = 0; i < makeArray.arguments.length; i++)
        this[i] = makeArray.arguments[i];
}

function getFullYear(d) {
    var y = d.getYear();
    if (y < 1000) { y += 1900 }
    return y;
}

var days = new makeArray("Niedziela", "Poniedziałek", "Wtorek", "Środa", "Czwartek", "Piątek", "Sobota");
var months = new makeArray("Styczeń", "Luty", "Marzec", "Kwiecień", "Maj", "Czerwiec", "Lipiec", "Sierpień", "Wrzesień", "Październik", "Listopad", "Grudzień");

function format_time(t) {
    var Day = t.getDay();
    var Date = t.getDate();
    var Month = t.getMonth();
    var Year = getFullYear(t);
    timeString = "";
    timeString += days[Day];
    timeString += ", ";
    timeString += Date;
    timeString += " ";
    timeString += months[Month];
    timeString += " ";
    timeString += Year;
    return timeString;
}

m = new Date(document.lastModified);
d = new Date();

document.getElementById("modify").innerHTML = format_time(m);

/* CLOCK */
function showTime() {
    var date = new Date();
    var h = date.getHours();
    var m = date.getMinutes();
    var s = date.getSeconds();
    var session = "AM";

    if (h == 0) {
        h = 12;
    }

    if (h > 12) {
        h = h - 12;
        session = "PM";
    }

    h = (h < 10) ? "0" + h : h;
    m = (m < 10) ? "0" + m : m;
    s = (s < 10) ? "0" + s : s;

    var time = h + ":" + m + ":" + s + " " + session;

    document.getElementById("clock").innerText = time;

    document.getElementById("clock").textContent = time;

    setTimeout(showTime, 1000);
}