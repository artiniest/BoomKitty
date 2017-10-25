using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetweenPoints : MonoBehaviour 
{
	public Transform[] points;
	public float moveSpeed = 10;
	public float distance = 2;

	public int count = 0;

	void FixedUpdate ()
	{
		Vector2 direction = Vector2.zero;
		direction = points[count].transform.position - transform.position;

		if (direction.magnitude < distance) 
		{
			if (count < points.Length) 
			{
				count++;
			}

			if (count == points.Length || count > points.Length) 
			{
				count = 0;
			}
		}

		direction = direction.normalized;
		Vector3 dir = direction;

		GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
	}

}
