let webrtc = new SimpleWebRTC({
    // we don't do video
    localVideoEl: '',
    remoteVideosEl: '',
    // dont ask for camera access
    autoRequestMedia: false,
    // dont negotiate media
    receiveMedia: {
        offerToReceiveAudio: 0,
        offerToReceiveVideo: 0
    }
});

$('#gameView').hide();
$('#joinButton').on('click', function (e) {
    let room = $('#gameRoom').val();
    console.log(room);
    webrtc.joinRoom(room);
})
webrtc.on('createdPeer', (peer) => {
    console.log(peer);
    $('#gameIntro').fadeOut();
    $('#gameView').fadeIn();
});