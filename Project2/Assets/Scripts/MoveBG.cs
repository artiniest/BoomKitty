using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBG : MonoBehaviour 
{
	public float moveSpeed = 10f; 

	Vector2 returnPos = new Vector2 (38, 0);

	void Update ()
	{
		transform.Translate (new Vector2 (moveSpeed * -Time.deltaTime, 0));

		if (gameObject.transform.position.x < -40) 
		{
			transform.position = returnPos;
		}
	}
}
