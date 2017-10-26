using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour 
{
	public int healthPoints = 3000;
	public Animator maattori;

	void Start ()
	{
		maattori = GetComponent<Animator> ();
	}

	void Update ()
	{
		if (healthPoints < 2950) 
		{
			maattori.SetBool ("hasTakenDmg", true);
		}

		if (healthPoints < 2900) 
		{
			maattori.SetBool ("isThisHisFinalForm", true);
		}
	}

	void SMALLSHAKE ()
	{
		ShakeScreen.shakeAmount = 0.1f;
		ShakeScreen.shakeDuration = 2f;
	}

	void MEDIUMSHAKE ()
	{
		ShakeScreen.shakeAmount = 0.2f;
		ShakeScreen.shakeDuration = 2f;
	}

	void BIGSHAKE ()
	{
		ShakeScreen.shakeAmount = 0.7f;
		ShakeScreen.shakeDuration = 5;
	}

	void OnTriggerEnter2D (Collider2D other) 
	{
		if (other.tag == "Bullet") 
		{
			healthPoints--;
		}
	}
}
