using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_pulsebubble : MonoBehaviour 
{
	public int numObjects = 10;
	public float initialSpawn = 2;
	public float repeatRate = 1;
	public GameObject prefab;

	void Start() 
	{
		InvokeRepeating ("Pulse", initialSpawn, repeatRate);
	}

	void Pulse ()
	{
		Vector3 center = transform.position;

		for (int i = 0; i < numObjects; i++)
		{
			Vector3 pos = RandomCircle(center, 5.0f);
			Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center-pos);
			Instantiate(prefab, pos, rot);
		}
	}

	Vector3 RandomCircle (Vector3 center, float radius)
	{
		float ang = Random.value * 360;
		Vector3 pos;
		pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
		pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
		pos.z = center.z;
		return pos;
	}
}
