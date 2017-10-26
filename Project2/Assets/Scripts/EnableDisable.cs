using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisable : MonoBehaviour 
{
	public GameObject toSpawn;

	void Awake ()
	{
		toSpawn.GetComponent<Bullet_pulsebubble> ().enabled = false;
		Invoke ("Spawn", 1f);
	}

	void Update ()
	{
		transform.position = Vector2.MoveTowards (new Vector2 (transform.position.x, transform.position.y), new Vector2(13, 0), 10 * Time.deltaTime);
	}

	void Spawn ()
	{
		toSpawn.GetComponent<Bullet_pulsebubble> ().enabled = true;
	}

}
