let moneyText = $('h1');
let lastSelected;
changeSelect($('.spawnButton').first());
$('.spawnButton').on('click', function (e) {
    changeSelect($(this));
})
function changeSelect(newSelect) {
    if(lastSelected) {
        lastSelected.removeClass('selected');
    }
    lastSelected = newSelect;
    newSelect.addClass('selected');
}
$('.rowButton').on('click', function(e) {
    let row = $(this).text();
    let unit = lastSelected.text();
    let command = "spawn "+unit+" "+row;
    sendCommand(command);
})
function sendCommand(comm) {
    console.log(comm);
    webrtc.sendToAll('chat', comm);
}
webrtc.connection.on('message', (data) => {
    if(data.type != 'chat') {
        return;
    }
    console.log(data);
})