using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CherryBombAI : Enemy {

	// Use this for initialization
	//private Pool bullets;
	//public GameObject bullet;
	//private static float bulletSpeed = 10;
	private static float fireRate = 2f;
	private bool canShoot = true;
	private float timeToNextShot = 0;
	private int mod;

	public Sprite[] frames; 
	public float framesPerSecond = 10.0f;


	void Start () {
		//bullets = new Pool (bullet, 3);

		this.gameObject.layer = base.side == "left" ? 10 : 11;
		base.range = 2;
		base.health = 10;
		base.speed = 3;
		mod = (base.side == "left" ? 1 : -1);
		if(side == "left"){
			GetComponent<SpriteRenderer> ().flipX = true;
		}
		//Attack ();
	}

	public void move(){
		this.GetComponent<Rigidbody2D>().velocity = transform.right * speed * mod;
	}

	public override bool canAttack(){
		RaycastHit2D check = Physics2D.Raycast (new Vector2(this.transform.position.x + (1f * mod), this.transform.position.y), Vector2.right * mod);
		if (check.transform != null && canShoot && check.transform.gameObject.layer != this.gameObject.layer && Mathf.Abs(check.transform.position.x - this.transform.position.x) < range) {
			//Debug.Log (check.transform.gameObject.name);
			return true;
		} else
			return false;
	}
	public bool canMove(){
		RaycastHit2D check = Physics2D.Raycast (new Vector2(this.transform.position.x + (1f * mod), this.transform.position.y), Vector2.right * mod);
		if (!canShoot) {
			return false;
			//Debug.Log ("Stuff");
		}
		if (check.transform == null)
			return true;
		if (Mathf.Abs (check.transform.position.x - this.transform.position.x) > range)
			return true;
		return false;
	}
	public override void Attack(){
		RaycastHit2D check1 = Physics2D.Raycast (new Vector2(this.transform.position.x + (1f * mod), this.transform.position.y), transform.right * mod);
		RaycastHit2D check2 = Physics2D.Raycast (new Vector2(this.transform.position.x, this.transform.position.y + 1.0f), transform.up);
		RaycastHit2D check3 = Physics2D.Raycast (new Vector2(this.transform.position.x, this.transform.position.y - 1.0f), -transform.up);

		if (check1.transform != null && Mathf.Abs (check1.transform.position.x - this.transform.position.x) < range)
			Destroy (check1.transform.gameObject);
		if (check2.transform != null && Mathf.Abs (check2.transform.position.y - this.transform.position.y) < range)
			Destroy (check2.transform.gameObject);
		if (check3.transform != null && Mathf.Abs (check3.transform.position.y - this.transform.position.y) < range)
			Destroy (check3.transform.gameObject);
		Destroy (this.gameObject);
	}


	// Update is called once per frame
	void Update () {
        if (transform.position.x > 10 || transform.position.x < -10) {
            Destroy(this.gameObject);
        }
        //Debug.Log (this.gameObject.name);
        int index = Convert.ToInt32(Time.time * framesPerSecond); 
		index = index % frames.Length;
        //Debug.Log("Current Indexx");
		GetComponent<SpriteRenderer>().sprite = frames[index]; 
		//canAttack ();
		speed = canShoot ? 2:0;
		if (canAttack ()) {
			//Debug.Log ("We attacked");
			Attack ();
		}
		move ();

		canShoot = timeToNextShot < Time.time;

	}
}
