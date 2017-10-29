using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour 
{
	public GameObject[] toSpanwn;
    public int whichOneTSPN;
	public GameObject[] enemies;
	public Transform spawnPoint;
	public GameObject borders;


	void Start () 
	{
       // InvokeRepeating("CustomUpdate", 0, 1);
	}

	/*void CustomUpdate ()
	{
		enemies = GameObject.FindGameObjectsWithTag ("EnemySpawner");

        if (enemies.Length == 0)
        {
            Invoke("SpawnBase", 5);
        }
	}*/

	public void Spawn0 ()
	{
		borders.gameObject.SetActive (false);
		Instantiate (toSpanwn [0], spawnPoint);
		Invoke ("EnableBorders", 2);
	}

   public void Spawn1 ()
    {
        borders.gameObject.SetActive(false);
        Instantiate(toSpanwn [1], spawnPoint);
        Invoke("EnableBorders", 2);
    }

    public void Spawn2 ()
    {
        borders.gameObject.SetActive(false);
        Instantiate(toSpanwn [2], spawnPoint);
        Invoke("EnableBorders", 2);
    }

    public void AHWEN ()
    {
        Application.LoadLevel(2);
    }

	void EnableBorders ()
	{
		borders.gameObject.SetActive (true);
	}
}
