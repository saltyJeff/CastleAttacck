using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Overlord : MonoBehaviour {

	// Use this for initialization
	public GameObject[] left; // size: 5
	public GameObject[] right; // size: 5

	//Enemy Type Prefabs
	public Transform Drill;
	public Transform PeaShooter;
	public Transform CherryBomb;
	public Transform Sentry;
    public Text text;
	void Start () {
        text = GameObject.Find("wintext").GetComponent<Text>();
        text.enabled = false;

        //text.enabled = true;
        //text.text = "side x wins"
	}

	public void SpawnLeft(int row, string type){
		switch (type) {
		case "DRILL":
			Transform temp = Instantiate (Drill, left [row].transform.position, left [row].transform.rotation);
			temp.gameObject.GetComponent<Enemy> ().side = "left";

			break;
		case "PEASHOOTER":
			Transform temp1 = Instantiate (PeaShooter, left [row].transform.position, left [row].transform.rotation);
			temp1.gameObject.GetComponent<Enemy>().side = "left";
			break;
		case "CHERRYBOMB":
			Transform temp2 = Instantiate (CherryBomb, left [row].transform.position, left [row].transform.rotation);
			temp2.gameObject.GetComponent<Enemy>().side = "left";
			break;
		case "SENTRY":
			Transform temp3 = Instantiate (Sentry, left [row].transform.position, left [row].transform.rotation);
			temp3.gameObject.GetComponent<Enemy>().side = "left";
			break;
		}
	}

	public void SpawnRight(int row, string type){
        Debug.Log("printing " + type);
		switch (type) {
		case "DRILL":
			Transform temp = Instantiate (Drill, right [row].transform.position, right [row].transform.rotation);
			temp.gameObject.GetComponent<Enemy>().side = "right";
			break;
		case "PEASHOOTER":
			Transform temp1 = Instantiate (PeaShooter, right [row].transform.position, right [row].transform.rotation);
			temp1.gameObject.GetComponent<Enemy>().side = "right";
			break;
		case "CHERRYBOMB":
			Transform temp2 = Instantiate (CherryBomb, right [row].transform.position, right [row].transform.rotation);
			temp2.gameObject.GetComponent<Enemy>().side = "right";
			break;
		case "SENTRY":
			Transform temp3 = Instantiate (Sentry, right [row].transform.position, right [row].transform.rotation);
			temp3.gameObject.GetComponent<Enemy>().side = "right";
			break;
		}
	}
}
