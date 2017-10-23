using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour 
{
	public GameObject bullett;
	public float spawnRate;

	void Start ()
	{
		InvokeRepeating ("Spawn", spawnRate+2, spawnRate);
	}

	void Update ()
	{
	}

	void Spawn () 
	{
		Instantiate (bullett, transform.position, Quaternion.identity);

			transform.Translate (new Vector2 (0, -1));

		//Invoken kautta kutsu 2 eri metodia, jossa siirretään objektia ylös ja alas acordingly
	}
}
