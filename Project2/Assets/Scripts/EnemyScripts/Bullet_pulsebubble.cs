using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_pulsebubble : MonoBehaviour 
{
	public static int numObjects = 30;
	public static float initialSpawn = 2;
	public static float repeatRate = 0.5f;
	public GameObject prefab;

	public Transform[] points;
	public float moveSpeed = 10;
	public float distance = 2;

    float waitTime = 2f;

	public int count = 0;

	void Start() 
	{
		InvokeRepeating ("Pulse", 0, repeatRate);
	}

	void FixedUpdate ()
	{
        if (points.Length > 0)
        {
            Vector2 direction = Vector2.zero;
            direction = points [count].transform.position - transform.position;

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
            GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
        }
	}
		
	void Pulse ()
	{
		Vector3 center = transform.position;

		for (int i = 0; i < numObjects; i++)
		{
			Vector3 pos = RandomCircle(center, 5.0f);
			Quaternion rot = Quaternion.FromToRotation(Vector2.right, center-pos);
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
