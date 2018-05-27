using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhettoCmd : MonoBehaviour {
    public string ID;
	public string command;
	public bool send = false;
	private EventQueue queue;
    public string SIDE;
    public int CASH;
	public void Start () {
		queue = GetComponent<EventQueue> ();
        PlayerBase.register(ID);
	}
	// Update is called once per frame
	void Update () {
        SIDE = PlayerBase.getSide(ID);
        CASH = PlayerBase.balance(ID);
		if (send) {
			queue.presentAction (ID + " " + command);
			send = false;
		}
	}
}
