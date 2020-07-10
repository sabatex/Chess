export function getEnabledGames(callBack,callBackError) {
    let xhttp = new XMLHttpRequest();
    xhttp.timeout = 9000;
    xhttp.open("GET", "/Chess?handler=gameList", true);
    xhttp.setRequestHeader('Content-Type', 'application/json');
    xhttp.setRequestHeader("XSRF-TOKEN", $('input:hidden[name="__RequestVerificationToken"]').val());
    xhttp.onload = function () {
        if (xhttp.status === 200) {
            callBack(JSON.parse(xhttp.response));
        }
    };
    xhttp.onerror = (event) => callBackError(event);
    xhttp.send();
}