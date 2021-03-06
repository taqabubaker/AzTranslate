// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

function saveFile(listName) {

    let originalList = $("#" + listName);
    let data = "";

    originalList.children().each(function (c) {
        data = data + this.innerText.concat("\n");
    });

    const textToBLOB = new Blob([data], { type: 'text/str' });
    const sFileName = listName + ".srt"; //The file to save the data.

    let newLink = document.createElement("a");
    newLink.download = sFileName;

    if (window.webkitURL !== null) {
        newLink.href = window.webkitURL.createObjectURL(textToBLOB);
    }
    else {
        newLink.href = window.URL.createObjectURL(textToBLOB);
        newLink.style.display = "none";
        document.body.appendChild(newLink);
    }

    newLink.click();
}

function logMessage(listName, message, lineSpliter) {
    let msgLines = message.split(lineSpliter);
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
}
