using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SentryAI : Enemy {

	// Use this for initialization
	private Pool bullets;
	public GameObject bullet;
	private static float bulletSpeed = 10;
	private static float fireRate = 2f;
	private bool canShoot = true;
	private float timeToNextShot = 0;
	private int mod;
	public Sprite[] frames; 
	public float framesPerSecond = 10.0f;
	void Start () {
		
		this.gameObject.layer = base.side == "left" ? 10 : 11;
		bullets = new Pool (bullet, 3);
		base.range = 5;
		base.health = 10;
		base.speed = 0;
		//Attack ();
		//mod = (base.side == "left" ? 1 : -1);
		if(side == "right"){
			GetComponent<SpriteRenderer> ().flipX = true;
		}
	}

	public override bool canAttack(){
		return canShoot;
	}

	public override void Attack(){
		if(canAttack())
			launchBullet ();
	}

	private void launchBullet() {
		GameObject b = bullets.getObj();
		b.transform.position = new Vector2(this.transform.position.x + (1f * (base.side == "left" ? 1 : -1)), this.transform.position.y);
		//b.transform.right *= (base.side == "left" ? 1 : -1);
		//b.GetComponent<Renderer>().material.color = playerColor;
		b.GetComponent<BulletScript>().prepare(bulletSpeed * (base.side == "left" ? 1 : -1));
		b.layer = this.gameObject.layer;
		timeToNextShot = Time.time + fireRate;
		/* Do later
		if(anim != null) {
			anim.SetTrigger("shoot");
		}
		*/
	}
	// Update is called once per frame
	void Update () {
		int index = Convert.ToInt32(Time.time * framesPerSecond); 
		index = index % frames.Length; 
		GetComponent<SpriteRenderer>().sprite = frames[index]; 
		canShoot = timeToNextShot < Time.time;
		Attack ();
			
	}
}
