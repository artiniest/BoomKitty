using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour 
{
	public GameObject[] toSpanwn;
	public Transform spawnPoint;
	public GameObject borders;


	void Start () 
	{
		Invoke ("Spawn1", 5);
	}

	void Spawn1 ()
	{
		borders.gameObject.SetActive (false);
		Instantiate (toSpanwn [0], spawnPoint);
	}
}
