using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour 
{
	public GameObject[] toSpanwn;
	public GameObject[] enemies;
	public Transform spawnPoint;
	public GameObject borders;


	void Start () 
	{
		Invoke ("Spawn1", 5);
	}

	void Update ()
	{

		enemies = GameObject.FindGameObjectsWithTag ("EnemySpawner");
	}

	void Spawn1 ()
	{
		borders.gameObject.SetActive (false);
		Instantiate (toSpanwn [0], spawnPoint);
		Invoke ("EnableBorders", 1);
	}

	void EnableBorders ()
	{
		borders.gameObject.SetActive (true);
	}
}
