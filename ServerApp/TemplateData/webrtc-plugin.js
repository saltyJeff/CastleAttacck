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

function joinRoom (s, obj) {
	

	let MASTER = 'RTC';
	if(obj) {
		MASTER = obj;
	}
	webrtc.on('createdPeer', function (peer) {
		console.log('createdPeer', peer);
		gameInstance.SendMessage(MASTER, 'onPeer', peer.id);
	});
	
	webrtc.connection.on('message', function (data) {
		if(data.type != 'chat') {
			return;
		}
		let gameMsg = data.from+" "+data.payload;
		console.log(gameMsg);
		gameInstance.SendMessage(MASTER, 'onMsg', gameMsg);
	});
	
	webrtc.joinRoom(s);
}