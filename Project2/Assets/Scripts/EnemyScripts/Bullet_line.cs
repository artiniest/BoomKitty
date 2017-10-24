using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_line : MonoBehaviour 
{
	GameObject pelaaja;
	int countLines = 0;

	private LineRenderer[] lines;

	void Awake () 
	{
		pelaaja = GameObject.FindGameObjectWithTag ("Player");
		lines = GetComponentsInChildren<LineRenderer> ();

		//lines [0].enabled = false;
		lines [1].enabled = false;
		lines [2].enabled = false;

		//InvokeRepeating ("StartAttack", 1,1);
	}

	void Update ()
	{
		lines [0].SetPosition (1, pelaaja.transform.position);
	}

	void StartAttack () 
	{
		if (countLines < lines.Length) 
		{
			Invoke ("Attack", 0);
		}
	}

	void Attack ()
	{
		lines [countLines].enabled = true;
		countLines++;
	}
}
