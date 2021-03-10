"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/translationhub").build();

connection.on("ReceiveMessage", function (listName, message) {
    var msgLines = message.split("\r\n");
    msgLines.forEach(function (line) {
        var li = document.createElement("li");

        if (line === "") {
            var p = document.createElement("p");
            li.appendChild(p);
        }
        else {
            li.textContent = line;
        }
        
        document.getElementById(listName).appendChild(li);
    });
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});