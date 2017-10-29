using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
	Vector2 mousePosition;
	Rigidbody2D rigby;
    Animator maattori;

	public static int hitPoints = 9;
	public float timer = 0.2f;
	public float bulletInterval = 0.2f;
	public float moveSpeed = 10f;

	public GameObject bullet;
    public AudioSource audiosourc;
	public GameObject topBoundary;
	public GameObject bottomBoundary;

	public static bool canMove = true;

	void Start ()
	{
        Cursor.visible = false;
		hitPoints = 9;
		rigby = GetComponent<Rigidbody2D> ();
        maattori = GetComponent<Animator>();
	}

	void Update ()
	{
		timer -= Time.deltaTime;

		if (Input.GetKey (KeyCode.Mouse0) && timer < 0 && canMove == true) 
		{
			Instantiate (bullet, transform.position, Quaternion.identity);
            audiosourc.Play();
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

        switch (hitPoints)
        {
            case 9:
                maattori.SetInteger("Health", 9);
                break;
            case 6:
                maattori.SetInteger("Health", 6);
                break;
            case 3:
                maattori.SetInteger("Health", 3);
                break;
            case 0:
                maattori.SetInteger("Health", 0);
                canMove = false;
                hitPoints = 0;
                break;
        }
        return;

		/*if (hitPoints < 1)
		{
			canMove = false;
			hitPoints = 0;
		}*/
	}
}
