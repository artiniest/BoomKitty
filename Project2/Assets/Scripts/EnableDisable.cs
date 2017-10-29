using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisable : MonoBehaviour 
{
	public GameObject[] toSpawn;

	void Awake ()
	{
        foreach (GameObject obj in toSpawn)
        {
            if (gameObject.name == "Spawn1")
            {
                gameObject.GetComponent<SpawnEnemies>().enabled = false;
                Invoke("Spawn", 1f);
            }
        }
	}

	void Update ()
	{
		transform.position = Vector2.MoveTowards (new Vector2 (transform.position.x, transform.position.y), new Vector2(5, 0), 10 * Time.deltaTime);
	}

	void Spawn ()
	{
        foreach (GameObject obj in toSpawn)
        {
            if (gameObject.name == "Spawn1")
            {
                obj.GetComponent<SpawnEnemies>().enabled = true;
            }

            else
            {
                obj.GetComponent<Bullet_pulsebubble>().enabled = true;
            }
        }
	}

}
