using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletScript : MonoBehaviour {
	private Rigidbody2D rb;
    private float dieTime;
	public void prepare (float bulletSpeed) {
        rb = GetComponent<Rigidbody2D>(); 
        rb.velocity = transform.right * bulletSpeed;
        dieTime = Time.time + 2;
	}
    private void Update() {
        if(Time.time > dieTime) {
            gameObject.SetActive(false);
        }
		else if (transform.position.x > 10 || transform.position.x < -10) {
			//Debug.Log ("shoof");
			gameObject.SetActive (false);
		}
    }
	private void OnTriggerEnter2D(Collider2D other)
	{

		if (other.gameObject.name == "Bullet" && other.gameObject.layer != this.gameObject.layer) {
			this.gameObject.SetActive (false);
			other.gameObject.SetActive (false);
		}

	}

}
