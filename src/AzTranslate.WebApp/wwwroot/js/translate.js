"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/translationhub").build();

connection.on("ReceiveTranscript", function (message) {
    var msgLines = message.split("\r\n");
    msgLines.forEach(function (line) {
        var li = document.createElement("li");
        li.textContent = line;
        document.getElementById("transcriptList").appendChild(li);
    });
});

connection.on("ReceiveTranslation", function (message) {
    var msgLines = message.split("\r\n");
    msgLines.forEach(function (line) {
        var li = document.createElement("li");
        li.textContent = line;
        document.getElementById("translationList").appendChild(li);
    });
});

connection.on("ReceiveLog", function (message) {
    var msgLines = message.split("\r\n");
    msgLines.forEach(function (line) {
        var li = document.createElement("li");
        li.textContent = line;
        document.getElementById("logList").appendChild(li);
    });
});

connection.start().then(function () {
    connection.invoke("StartTranslation").catch(function (err) {
        return console.error(err.toString());
    });
}).catch(function (err) {
    return console.error(err.toString());
});