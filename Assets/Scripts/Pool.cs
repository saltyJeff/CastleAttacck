using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Pool {
	protected List<GameObject> pool = new List<GameObject> ();
	protected GameObject thisType;
	protected GameObject baseObj;
	public Pool(GameObject g, int n) {
		thisType = g;
		baseObj = new GameObject();
		baseObj.name = thisType.name;
		for(int i = 0; i < n; i++) {
			GameObject temp = (GameObject)MonoBehaviour.Instantiate(thisType);
			temp.name = thisType.name;
			temp.transform.SetParent(baseObj.transform);
			temp.SetActive(false);
			pool.Add(temp);
		}
	}
	public GameObject getObj () {

		for (int i = 0; i < pool.Count; i++) {
			if(!pool[i].activeInHierarchy) {
				pool[i].SetActive(true);
				pool [i].transform.position = Vector2.zero;
				return pool[i];
			}
		}
		GameObject temp = (GameObject)MonoBehaviour.Instantiate(thisType);
		temp.name = thisType.name;
		temp.transform.SetParent(baseObj.transform);
		temp.transform.position = Vector2.zero;
		pool.Add(temp);
		return temp;
	}
}
