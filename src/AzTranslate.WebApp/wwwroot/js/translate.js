"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/translationhub").build();

connection.on("ReceiveMessage", function (listName, message) {
    let msgLines = message.split("\r\n");
    msgLines.forEach(function (line) {
        let li = document.createElement("li");

        if (line === "") {
            let p = document.createElement("p");
            li.appendChild(p);
        }
        else {
            li.textContent = line;
        }

        let list = document.getElementById(listName);
        list.appendChild(li);

        let div = $(list).parent(".pre-scrollable");
        $(div).scrollTop($(div)[0].scrollHeight);
    });
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});