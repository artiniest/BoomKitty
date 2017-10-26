using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_hitpoints : MonoBehaviour 
{
	public int hitPoints;

	void Start () 
	{
		if (gameObject.tag == "Enemy10HP") 
		{
			hitPoints = 10;
		}

		if (gameObject.tag == "Enemy20HP") 
		{
			hitPoints = 20;
		}
	}

	void Update ()
	{
		if (hitPoints < 1) 
		{
			Destroy (this.gameObject);
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Bullet") 
		{
			Destroy (other.gameObject);
			hitPoints--;
		}
	}
}
