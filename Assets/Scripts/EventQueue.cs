using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventQueue : MonoBehaviour {
    private Queue<Action> queue = new Queue<Action>();
	//public GameObject control;
	private Overlord Controller;

	// Use this for initialization
	void Start () {
		Controller = this.GetComponent<Overlord> ();
        //restart this later
		StartCoroutine("RunLoop");
	}
	IEnumerator RunLoop() {
        Debug.Log("Loop warmed");
        Action act = null;
        while (true) {
            while (queue.Count == 0) {
                //Debug.Log("empty queue");
                yield return null;
            }
            act = queue.Dequeue();
            act();
            yield return null;
        }
    }
    public void presentAction(String s) {
        Debug.Log("Parsing "+s);
        Action a = parseAction(s);
        queue.Enqueue(a);
    }
    private Action parseAction(String s) {
        Debug.Log("exec: " + s);
		string[] tokens = s.Split (' ');
        string id = tokens[0];
        string command = tokens[1];
		Action fun = () => {
            switch(command) {
                case "spawn":
                    tokens[2] = tokens[2].ToUpper();
                    int charge = PlayerBase.unitCosts[tokens[2]];
                    int balance = PlayerBase.balance(id);
                    if(balance < charge) {
                        return;
                    }
                    PlayerBase.charge(id, -charge);

                    if (PlayerBase.getSide(id) == "LEFT") {
                        Controller.SpawnLeft(Convert.ToInt32(tokens[3]), tokens[2]);
                    }
                    else if (PlayerBase.getSide(id) == "RIGHT") {
                        Controller.SpawnRight(Convert.ToInt32(tokens[3]), tokens[2]);
                    }
                    break;
                case "balance":
                    break;
            }
		};
		//Aravind work here
        /*
         * based on the string coming in, turn it into an action. It will automatically be
         * pushed into the queue.
        */
		return fun;
    }
}
