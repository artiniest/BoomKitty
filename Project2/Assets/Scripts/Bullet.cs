using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour 
{
	public float bullSpeed = 10f;

	void Update () 
	{
		transform.Translate (new Vector2 (bullSpeed* Time.deltaTime, 0));

		if (transform.position.x > 25) 
		{
			Destroy (gameObject);
		}
	}
}
