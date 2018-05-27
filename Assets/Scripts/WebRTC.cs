using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebRTC : MonoBehaviour {
    private EventQueue queue;
	// Use this for initialization
	void Start () {
        queue = GetComponent<EventQueue>();
        Application.ExternalCall("joinRoom", "CODEDAY", gameObject.name);
	}
    void onPeer(string s) {
        PlayerBase.register(s);
    }
	void onMsg(string s) {
        Debug.Log("bridge msg: "+s);
        queue.presentAction(s);
    }
}
