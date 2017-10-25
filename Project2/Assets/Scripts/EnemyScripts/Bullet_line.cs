using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_line : MonoBehaviour
{
    GameObject pelaaja;
	public static Vector2 playerPos;
    int countLines = 0;

    private LineRenderer [] lines;
    public float rateOfAttack = 0.5f;
    public float waitTime = 2f;
    private Material [] materials;
    Material matToAssign;

    void Awake ()
    {
        pelaaja = GameObject.FindGameObjectWithTag("Player");
        lines = GetComponentsInChildren<LineRenderer>();
        materials = GetComponentInChildren<LineRenderer>().materials;

        foreach (LineRenderer rendo in lines)
        {
            rendo.enabled = false;
            rendo.material = materials [1];
        }
    }

    void OnEnable ()
    {
        InvokeRepeating("StartAttack", 1, rateOfAttack);
    }

    void StartAttack ()
    {
        if (countLines < lines.Length)
        {
            Invoke("Attack", 0);
        }

        else if (countLines == lines.Length)
        {
            Invoke("Hurt", waitTime);
        }

        else if (countLines > lines.Length)
        {
            Invoke("Disable", waitTime);
        }
    }

    void Attack ()
    {
		playerPos = pelaaja.transform.position;
		lines [countLines].SetPosition(1, new Vector3(-22.8f, playerPos.y, 0));
        lines [countLines].enabled = true;
        countLines++;
    }

    void Hurt ()
    {
        foreach (LineRenderer rendo in lines)
        {
            rendo.material = materials [0];
			rendo.widthMultiplier = 0.75f;
        }

        countLines++;
    }

    void Disable ()
    {
        foreach (LineRenderer rendo in lines)
        {
            rendo.enabled = false;
        }
    }
}
