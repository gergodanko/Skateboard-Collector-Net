var globalId;
var globalType;
function onDecksReceived() {
    const decks = JSON.parse(this.responseText);
    const div = document.getElementById("main");
    const deckDiv = document.createElement("div");
    var header = document.createElement("h2");
    header.innerText = "Decks";
    deckDiv.appendChild(header);
    deckDiv.style.display = "block";
    deckDiv.setAttribute("id", "deckDiv");
    div.appendChild(deckDiv);
    const table = document.createElement("table");
    table.setAttribute("width", "100%");
    table.setAttribute("border-spacing", "5px");
    deckDiv.appendChild(table);
    var hrow = table.insertRow(0);
    var hcell0 = document.createElement('th');
    hcell0.setAttribute("width", "200");
    var hcell1 = document.createElement('th');
    var hcell2 = document.createElement('th');
    var hcell3 = document.createElement('th');
    hcell1.innerHTML = "Brand";
    hcell2.innerHTML= "Width";
    hcell3.innerHTML = "Length";
    hrow.appendChild(hcell0);
    hrow.appendChild(hcell1);
    hrow.appendChild(hcell2);
    hrow.appendChild(hcell3);
    decks.forEach(q => {
        var i = 1;
        var row = table.insertRow(i);
        var id = q.deckId;
        var type = "Deck";
        var brand = q.deckBrand;
        var width = q.deckWidth;
        var length = q.deckLength;
        var cell0 = row.insertCell(0)
        var cell1 = row.insertCell(1);
        var cell2 = row.insertCell(2);
        var cell3 = row.insertCell(3);
        var cell4 = document.createElement('td');
        var addButton = document.createElement("button");
        addButton.setAttribute("class", "btn btn-secondary ");
        addButton.innerText = "Add to skateboard";
        addButton.onclick = function () {
            //addToSkateboard(id, type);
            globalId = id;
            globalType = type;
            getUserSkateboards();
        }
        cell4.appendChild(addButton);
        row.appendChild(cell4);
        var image = document.createElement("img");
        image.setAttribute("src", "https://placehold.it/150x150?text=150x150");
        image.setAttribute("width", "150");
        cell0.appendChild(image);
        cell1.innerHTML = brand;
        cell2.innerHTML = width;
        cell3.innerHTML = length;
        i = i + 1;
        
    })
}
function onTrucksReceived() {
    const trucks = JSON.parse(this.responseText);
    const div = document.getElementById("main");
    const truckDiv = document.createElement("div");
    var header = document.createElement("h2");
    header.innerText = "Trucks";
    truckDiv.appendChild(header);
    truckDiv.style.display = "none";
    truckDiv.setAttribute("id", "truckDiv");
    div.appendChild(truckDiv);
    const table = document.createElement("table");
    table.setAttribute("width", "80%");
    table.setAttribute("border-spacing", "5px");
    truckDiv.appendChild(table);
    var hrow = table.insertRow(0);
    var hcell0 = document.createElement('th');
    hcell0.setAttribute("width", "200");
    var hcell1 = document.createElement('th');
    var hcell2 = document.createElement('th');
    hcell1.innerHTML = "Brand";
    hcell2.innerHTML = "Size";
    hrow.appendChild(hcell0);
    hrow.appendChild(hcell1);
    hrow.appendChild(hcell2);
    trucks.forEach(q => {
        var i = 1;
        var row = table.insertRow(i);
        var id = q.truckId;
        var type = "Truck";
        var brand = q.truckBrand;
        var size = q.truckSize;
        var cell0 = row.insertCell(0)
        var cell1 = row.insertCell(1);
        var cell2 = row.insertCell(2);
        var cell3 = document.createElement('td');
        var addButton = document.createElement("button");
        addButton.setAttribute("class", "btn btn-secondary ");
        addButton.innerText = "Add to skateboard";
        addButton.onclick = function () {
            //addToSkateboard(id, type);
            globalId = id;
            globalType = type;
            getUserSkateboards();
        }
        cell3.appendChild(addButton);
        row.appendChild(cell3);
        var image = document.createElement("img");
        image.setAttribute("src", "https://placehold.it/150x150?text=150x150");
        image.setAttribute("width", "150");
       cell0.appendChild(image);
        cell1.innerHTML = brand;
        cell2.innerHTML = size;
        
        i = i + 1;

    })
}


function onWheelsReceived() {
    const wheels = JSON.parse(this.responseText);
    const div = document.getElementById("main");
    const wheelsDiv = document.createElement("div");
    var header = document.createElement("h2");
    header.innerText = "Wheels";
    wheelsDiv.appendChild(header);
    wheelsDiv.style.display = "none";
    wheelsDiv.setAttribute("id", "wheelsDiv");
    div.appendChild(wheelsDiv);
    const table = document.createElement("table");
    table.setAttribute("width", "100%");
    table.setAttribute("border-spacing", "5px");
    wheelsDiv.appendChild(table);
    var hrow = table.insertRow(0);
    var hcell0 = document.createElement('th');
    hcell0.setAttribute("width", "200");
    var hcell1 = document.createElement('th');
    var hcell2 = document.createElement('th');
    var hcell3 = document.createElement('th');
    hcell1.innerHTML = "Brand";
    hcell2.innerHTML = "Size";
    hcell3.innerHTML = "Hardness"
    hrow.appendChild(hcell0);
    hrow.appendChild(hcell1);
    hrow.appendChild(hcell2);
    hrow.appendChild(hcell3);
    wheels.forEach(q => {
        var i = 1;
        var row = table.insertRow(i);
        var id = q.wheelsId;
        var type = "Wheels";
        var brand = q.wheelsBrand;
        var size = q.wheelsSize;
        var hardness = q.wheelsHardness
        var cell0 = row.insertCell(0)
        var cell1 = row.insertCell(1);
        var cell2 = row.insertCell(2);
        var cell3 = row.insertCell(3);
        var cell4 = document.createElement('td');
        var addButton = document.createElement("button");
        addButton.setAttribute("class", "btn btn-secondary ");
        addButton.innerText = "Add to skateboard";
        addButton.onclick = function () {
            //addToSkateboard(id, type);
            globalId = id;
            globalType = type;
            getUserSkateboards();
        }
        cell4.appendChild(addButton);
        row.appendChild(cell4);
        var image = document.createElement("img");
        image.setAttribute("src", "https://placehold.it/150x150?text=150x150");
        image.setAttribute("width", "150");
        cell0.appendChild(image);
        cell1.innerHTML = brand;
        cell2.innerHTML = size;
        cell3.innerHTML = hardness;
        i = i + 1;

    })
}

function openModal() {
    const skateboards = JSON.parse(this.responseText);
    $('#addBoardModal').modal("show");
    var boardTable = document.getElementById("boardTable");
    var successDiv = document.getElementById("successDiv");
    successDiv.style.visibility= "hidden";
    boardTable.style.visibility = "visible";
    while (boardTable.firstChild) {
        boardTable.removeChild(boardTable.firstChild)
    }
    var hrow = boardTable.insertRow(0);
    var hcell1 = document.createElement('th');
    var hcell2 = document.createElement('th');
    var hcell3 = document.createElement('th');
    var hcell4 = document.createElement('th');
    hcell1.innerHTML = "Deck";
    hcell2.innerHTML = "Truck";
    hcell3.innerHTML = "Wheels"
    hrow.appendChild(hcell1);
    hrow.appendChild(hcell2);
    hrow.appendChild(hcell3);
    hrow.appendChild(hcell4);

    
    skateboards.forEach(q => {
        var index = 1;
        var row = boardTable.insertRow(index);
        var boardId = q.skateboardId;
        var deckString;
        var truckString;
        var wheelsString;
        if (q.sbDeck.deckId == 0) {
            deckString = "You haven't set a deck\nfor this board yet!"
        }
        else{
            deckString = "Brand: " + q.sbDeck.deckBrand + "\n" + "Width: " + q.sbDeck.deckWidth + "\n" + "Length: " + q.sbDeck.deckLength;
        }
        if (q.sbTrucks.truckId == 0) {
            truckString = "You haven't set a truck\nfor this board yet!"
        }
        else {
            truckString = "Brand: " + q.sbTrucks.truckBrand + "\n" + "Size: " + q.sbTrucks.truckSize;
        }
        if (q.sbWheels.wheelsId == 0) {
            wheelsString = "You haven't set wheels\nfor this board yet!"
        }
        else {
            wheelsString = "Brand: " + q.sbWheels.wheelsBrand + "\n" + "Size: " + q.sbWheels.wheelsSize + "\n" + "Hardness: " + q.sbWheels.wheelsHardness
        }
        var cell1 = row.insertCell(0);
        var cell2 = row.insertCell(1);
        var cell3 = row.insertCell(2);
        var cell4 = document.createElement('td');
        var addButton = document.createElement("button");
        addButton.setAttribute("class", "btn btn-secondary");
        addButton.innerText = "Add";
        addButton.onclick = function () {
            addToSkateboard(boardId, globalId, globalType)
            successDiv.style.visibility = "visible";
            //$('#addBoardModal').modal("hide");
        }
        cell4.appendChild(addButton);
        row.appendChild(cell4);
        cell1.innerHTML = deckString;
        cell2.innerHTML = truckString;
        cell3.innerHTML = wheelsString;
        index = index+1
    })
}

function getUserSkateboards() {
    const xhr = new XMLHttpRequest();
    xhr.addEventListener("load", openModal);
    xhr.open('GET', 'https://localhost:44382/api/Shop/GetUserSkateboards');
    xhr.send();
}
function addToSkateboard(boardId, hardwareId, hardwareType) {
    const xhr = new XMLHttpRequest();
    var data = new FormData();
    data.append("boardId", boardId);
    data.append("hardwareId", hardwareId);
    data.append("hardwareType", hardwareType);
    //xhr.addEventListener('load', onDecksReceived);
    xhr.open('POST', 'https://localhost:44382/api/Shop/UpdateBoard');
    xhr.send(data);
}

function deckButton() {
    var decks = document.getElementById("deckDiv");
    var trucks = document.getElementById("truckDiv");
    var wheels = document.getElementById("wheelsDiv");
    trucks.style.display = "none";
    wheels.style.display = "none";
    decks.style.display = "block";
}
function truckButton() {
    var decks = document.getElementById("deckDiv");
    var trucks = document.getElementById("truckDiv");
    var wheels = document.getElementById("wheelsDiv");
    var header = document.getElementById("header");
    //header.innerHTML("Trucks")
    decks.style.display = "none";
    wheels.style.display = "none";
    trucks.style.display = "block";

}
function wheelsButton() {
    var decks = document.getElementById("deckDiv");
    var trucks = document.getElementById("truckDiv");
    var wheels = document.getElementById("wheelsDiv");
    var header = document.getElementById("header");
    //header.innerHTML("Wheels")
    trucks.style.display = "none";
    decks.style.display = "none";
    wheels.style.display = "block";

}
function getWheels() {
    const xhr = new XMLHttpRequest();
    xhr.addEventListener("load", onWheelsReceived);
    xhr.open('GET', 'https://localhost:44382/api/Shop/GetAllWheels');
    xhr.send();
}
function getTrucks() {
    const xhr = new XMLHttpRequest();
    xhr.addEventListener("load", onTrucksReceived);
    xhr.open('GET', 'https://localhost:44382/api/Shop/GetAllTrucks');
    xhr.send();
}
function getDecks() {
    const xhr = new XMLHttpRequest();
    xhr.addEventListener('load', onDecksReceived);
    xhr.open('GET', 'https://localhost:44382/api/Shop/GetAllDecks');
    xhr.send();
}

function init() {
    getDecks();
    getTrucks();
    getWheels();

}
init();