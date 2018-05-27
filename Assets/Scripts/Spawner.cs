/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    private Pool eyePool;
    public GameObject eyes;
    private float nextTime;
    public float eyeballDieTime = 3;
    public float spawnRate = 1.5f;
    public float eyeSpeed = 3;
    public Transform barrel;
    // Use this for initialization
    void Start () {
        eyePool = new Pool(eyes, 5);
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time >= nextTime) {
            launchEyes();
        }
	}

    void launchEyes() {
        GameObject b = eyePool.getObj();
        b.transform.position = barrel.transform.position;
        b.transform.rotation = barrel.transform.rotation;
        Debug.DebugBreak();
        b.GetComponent<EyeballScript>().prepare(eyeSpeed, eyeballDieTime);
        nextTime = Time.time + spawnRate;
    }
}
*/