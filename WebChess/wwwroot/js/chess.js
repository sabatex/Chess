import { ChessDesk, chessDesk, setChessDesk, chessDeskCellClick } from "./chess/ChessDesk.js";
import { ChessConst, GameState } from "./chess/GameState.js";
import { getEnabledGames } from "./chess/ServerApi.js";


function drawChessTableOutside(htmlElement){
    for (let s of ['', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', '']) {
        $('<DIV>').addClass('gripDeskRow').css('grid-row', '1/1').text(s).appendTo(htmlElement);
        $('<DIV>').addClass('gripDeskRow').css('grid-row', '10/10').text(s).appendTo(htmlElement);
    }
    for (let i = 1; i < 9; i++) {
        $('<DIV>').addClass('gripDeskColumn').css('grid-column', '1/1').text(i).appendTo(htmlElement);
        $('<DIV>').addClass('gripDeskColumn').css('grid-column', '10/10').text(i).appendTo(htmlElement);
    }


    appendDIV(htmlElement, "gripDeskColumn", "1");
    var mainChessTable = appendDIV(htmlElement, "chessCelsTable", "");
    for (let s of ["1", "2", "2", "3", "3", "4", "4", "5", "5", "6", "6", "7", "7", "8", "8"]) {
        appendDIV(htmlElement, "gripDeskColumn", s);
    }
    //for (let s of ['', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', '']) {
    //    appendDIV(htmlElement, "gripDeskRow", s);
    //}
    return mainChessTable;
}

function selectGame() {

}

window.chess = new function () {
    this.clickCell = function (event) {
        let a = 10;
    }
    this.initialDesk = function () {
        this.leftPanel.empty();
        for (let s of ['', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', '']) {
            $('<DIV>').addClass('gripDeskRow').css('grid-row', '1/1').text(s).appendTo(this.leftPanel);
            $('<DIV>').addClass('gripDeskRow').css('grid-row', '10/10').text(s).appendTo(this.leftPanel);
        }
        for (let i = 1; i < 9; i++) {
            $('<DIV>').addClass('gripDeskColumn').css('grid-column', '1/1').text(i).appendTo(this.leftPanel);
            $('<DIV>').addClass('gripDeskColumn').css('grid-column', '10/10').text(i).appendTo(this.leftPanel);
        }
        let chessTable = $('<DIV>').addClass("chessCelsTable").css('grid-area', '2/2/10/10').appendTo(this.leftPanel);
        for (let i = 0; i < 8; i++) {
            for (let j = 0; j < 8; j++) {
                let cellElement = $('<DIV>').addClass("chessCell").attr("id", "cell" + i + j).click(this.clickCell).appendTo(chessTable);
                if ((i + j) % 2) cellElement.addClass("blackCell");
            }
        }
    }
    this.initialSelectGame = function (gamesList) {
        this.leftDesk.empty();
    }
    this.initialInfoPanel = function () {

    }
    this.initialPlayer1 = function () {

    }
    this.initialPlayer2 = function () {

    }



    Object.defineProperty(this, "state", {
        get: function () { this._state; },
        set: function (value) {
            switch (value) {
                case GameState.waitForSelectGame: {
                    this._state = value;
                    getEnabledGames(this.initialSelectGame, () => { });
                }
            }
        }
    });


    // initial chess desk
    let mainElement = document.getElementById(ChessConst.mainElement);
    this.leftPanel = $('<DIV>').attr('id', ChessConst.rightPanel)
        .addClass(ChessConst.cssChessTable).appendTo(mainElement);

    this.rigthPanel = $('<DIV>').addClass(ChessConst.rightPanel).appendTo(mainElement);
    this.infoPanel = $('<DIV>').addClass(ChessConst.cssPlayerStatus).appendTo(this.rigthPanel);
    this.playerPanel1 = $('<DIV>').addClass(ChessConst.cssPlayer1).appendTo(this.rigthPanel);
    this.playerPanel2 = $('<DIV>').addClass(ChessConst.cssPlayer1).appendTo(this.rigthPanel);

    let party = $('#Party').get(0).value;
    if (party == '') {
        this.state = GameState.waitForSelectGame;
        return;
    }
    


    this.initialDesk();
}


//// initial chess desk
//var htmlElement = document.getElementById("chessDesk");
//// chessTable 
////var chessTableElement = appendDIV(htmlElement, "chessTable", "");
//var chessTableElement = drawChessTableOutside(appendDIV(htmlElement, "chessTable", ""));
//for (let i = 0; i < 8; i++) {
//    for (let j = 0; j < 8; j++) {
//        let cellElement = appendDIV(chessTableElement, "chessCell", "");
//        if ((i + j) % 2) cellElement.classList.add("blackCell");
//        cellElement.id = "cell" + i + j;
//        cellElement.onclick = chessDeskCellClick;

//    }
//}

//// Player Desk
//var playerDeskElement = appendDIV(htmlElement, "playerDesk", "");
//appendDIV(playerDeskElement, "playerStatus", "Please wait ...");

//appendDIV(playerDeskElement, "userBlackDashBoard userDashBoard", "");
//appendDIV(playerDeskElement, "userWhiteDashBoard userDashBoard", "");

//window.dashBoard = new DashBoard(playerDeskElement);
//window.chessDesk = new ChessDesk();


//let party = $("#Party").get(0);

//if (currentGame == "") {
//    selectGame();
//}
//else {
//    var result = JSON.parse(document.getElementById("InitialDesk").value);
//    setChessDesk(new ChessDesk(result));
//    chessDesk.refreshDesk();

//}


//ajax get desk
var ChessAPIGetDesk = function () {
    let xhttp = new XMLHttpRequest();

    xhttp.timeout = 9000;
    xhttp.open("GET", "/Chess?handler=desk", true);
    xhttp.setRequestHeader('Content-Type', 'application/json');
    xhttp.setRequestHeader("XSRF-TOKEN", $('input:hidden[name="__RequestVerificationToken"]').val());
    xhttp.onload = function () {
        if (xhttp.status === 200) {
            var result = JSON.parse(xhttp.response);
            setChessDesk(new ChessDesk(result));
            chessDesk.refreshDesk();

        }
    };
    xhttp.onreadystatechange = function () {
        // In local files, status is 0 upon success in Mozilla Firefox
        if (xhttp.readyState === XMLHttpRequest.DONE) {
            var status = xhttp.status;
            if (status === 0 || (status >= 200 && status < 400)) {
                // The request has been completed successfully
                //var result = JSON.parse(xhttp.response);

                //result.__prototype__ = ChessDesk;
                //chessDesk = result;
                //chessDesk.refreshDesk();

                //console.log(xhttp.response);
            } else {
                // Oh no! There has been an error with the request!
            }
        }
    };
    xhttp.send();
}




