using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisable : MonoBehaviour 
{
	public GameObject toSpawn;

	void Awake ()
	{
		toSpawn.GetComponent<Bullet_pulsebubble> ().enabled = false;
		Invoke ("StartSpawn", 0);
	}

	void StartSpawn ()
	{
		transform.Translate (new Vector2 (-8, 0));
		Invoke ("Spawn", 5);
	}

	void Spawn ()
	{
		toSpawn.GetComponent<Bullet_pulsebubble> ().enabled = true;
	}

}
