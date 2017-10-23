using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
	Vector2 mousePosition;
	Rigidbody rigby;

	public float timer = 0.2f;
	public float bulletInterval = 0.2f;
	public float moveSpeed = 10f;
	public float startLocation = -14;
	public GameObject bullet;
	public GameObject topBoundary;
	public GameObject bottomBoundary;

	bool canMove = true;

	void Start ()
	{
		rigby = GetComponent<Rigidbody> ();
	}

	void Update ()
	{
		timer -= Time.deltaTime;

		if (Input.GetKey (KeyCode.Mouse0) && timer < 0) 
		{
			Instantiate (bullet, transform.position, Quaternion.identity);
			timer = 0.2f;
		}
	}

	void FixedUpdate ()
	{ 
		if (canMove == true) {
			mousePosition = Input.mousePosition;
			mousePosition = Camera.main.ScreenToWorldPoint (mousePosition);
			rigby.MovePosition (transform.position = Vector2.Lerp (transform.position, new Vector2 (startLocation, mousePosition.y), moveSpeed * Time.deltaTime));
		}
	}
}
