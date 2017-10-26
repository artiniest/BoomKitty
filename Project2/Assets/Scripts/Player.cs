using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
	Vector2 mousePosition;
	Rigidbody2D rigby;

	public static int hitPoints = 5;
	public float timer = 0.2f;
	public float bulletInterval = 0.2f;
	public float moveSpeed = 10f;

	public GameObject bullet;
	public GameObject topBoundary;
	public GameObject bottomBoundary;

	public static bool canMove = true;

	void Start ()
	{
		hitPoints = 5;
		rigby = GetComponent<Rigidbody2D> ();
	}

	void Update ()
	{
		timer -= Time.deltaTime;

		if (Input.GetKey (KeyCode.Mouse0) && timer < 0 && canMove == true) 
		{
			Instantiate (bullet, transform.position, Quaternion.identity);
			timer = 0.09f;
		}

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Application.LoadLevel(0);
        }
	}

	void FixedUpdate ()
	{ 
		if (canMove == true) 
		{
			mousePosition = Input.mousePosition;
			mousePosition = Camera.main.ScreenToWorldPoint (mousePosition);
			rigby.MovePosition (transform.position = Vector2.Lerp (transform.position, new Vector2 (mousePosition.x, mousePosition.y), moveSpeed * Time.deltaTime));
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag != "Bullet") 
		{
			hitPoints--;
		}
		if (hitPoints < 1)
		{
			canMove = false;
			hitPoints = 0;
		}
	}
}
