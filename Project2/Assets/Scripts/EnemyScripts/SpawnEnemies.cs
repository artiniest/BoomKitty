using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour 
{
    public bool movingDown;
    public GameObject bullett;
    public GameObject topBounce;
    public GameObject botBounce;

	public float spawnRate;

	void Start ()
	{
		InvokeRepeating ("Spawn", spawnRate + 2, spawnRate);
	}

    void Update ()
    {
        if (transform.position.y < botBounce.transform.position.y)
        {
            movingDown = false;
        }

        if (transform.position.y > topBounce.transform.position.y)
        {
            movingDown = true;
        }
    }

    void Spawn ()
    {
		if (transform.childCount != 0) 
		{
			Instantiate (bullett, transform.position, Quaternion.identity);

			if (movingDown == true) {
				transform.Translate (new Vector2 (0, -1));
			}

			if (movingDown == false) {
				transform.Translate (new Vector2 (0, +1));
			}
		}
	}
}
