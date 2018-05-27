using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {
	//require implementation:
	public abstract bool canAttack();
	public abstract void Attack ();

	//Pre-Done Stuffs:
	public int range;
	public int speed;
	public string side;
	public int health;


	public void takeDamage(int damage){
		health -= damage;
		if (health <= 0)
			death ();
	}
	public void death(){
		//Do the death animation stuff before destroy

		//Acctual Death T_T
		Destroy(this.gameObject);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{

		if (other.gameObject.name == "Bullet" && other.gameObject.layer != this.gameObject.layer) {
			other.gameObject.SetActive (false);
			takeDamage (5);
		}

	}
}
