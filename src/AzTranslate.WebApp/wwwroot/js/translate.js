"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/translationhub").build();

connection.on("ReceiveMessage", function (listName, message, lineSpliter) {
    logMessage(listName, message, lineSpliter);
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});