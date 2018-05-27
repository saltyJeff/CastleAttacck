using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DrillAI : Enemy {

	// Use this for initialization
	private Pool bullets;
	//public GameObject bullet;
	private static float bulletSpeed = 10;
	private static float fireRate = 2f;
	private bool canShoot = true;
	private float timeToNextShot = 0;
	private int mod;
    public GameObject control;
	public Sprite[] frames; 
	public float framesPerSecond = 10.0f;


	void Start () {
        //bullets = new Pool (bullet, 3);
        control = GameObject.Find("GameController");
        this.gameObject.layer = base.side == "left" ? 10 : 11;
		base.range = 3;
		base.health = 10;
		base.speed = 2;
		mod = (base.side == "left" ? 1 : -1);
		if(side == "right"){
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
			return true;
		} else
			return false;
	}
	public bool canMove(){
		RaycastHit2D check = Physics2D.Raycast (new Vector2(this.transform.position.x + (1f * mod), this.transform.position.y), Vector2.right * mod);
		if (!canShoot) {
			return false;
			Debug.Log ("Stuff");
		}
		if (check.transform == null)
			return true;
		if (Mathf.Abs (check.transform.position.x - this.transform.position.x) > range)
			return true;
		return false;
	}
	public override void Attack(){
		RaycastHit2D check = Physics2D.Raycast (new Vector2(this.transform.position.x + (1f * mod), this.transform.position.y), transform.right * mod);


			GameObject other = check.transform.gameObject;

			switch(other.name){
				case "Drill(Clone)":
				DrillAI drill = other.GetComponent<DrillAI> ();
				drill.takeDamage (5);
			timeToNextShot = Time.time + fireRate;
				break;
			case "SentryTurret(Clone)":
				SentryAI sentry = other.GetComponent<SentryAI> ();
				sentry.takeDamage (5);
			timeToNextShot = Time.time + fireRate;
				break;
				
			case "CherryBomb":
				CherryBombAI cherryBomb = other.GetComponent<CherryBombAI> ();
				cherryBomb.takeDamage (5);
				break;
                /*
			case "PeaShooter":
				PeaShooterAI peaShooter = other.GetComponent<PeaShooterAI> ();
				peaShooter.takeDamage (5);
				break;
				*/
			default:
				break;
			}
				
			


	}


	// Update is called once per frame
	void Update () {
        if (transform.position.x > 10 || transform.position.x < -10) {
            Destroy(this.gameObject);
            
            Overlord temp = control.GetComponent<Overlord>();
            temp.text.enabled = true;
            temp.text.text = "side " + (this.gameObject.layer == 10 ? "left":"right") + " wins";
            
        }
        int index = Convert.ToInt32(Time.time * framesPerSecond); 
		index = index % frames.Length; 
		GetComponent<SpriteRenderer>().sprite = frames[index]; 
		//canAttack ();
		speed = canShoot ? 2:0;
		if (canAttack ()) {
			Attack ();
		}
		move ();
		
		canShoot = timeToNextShot < Time.time;

	}
}
