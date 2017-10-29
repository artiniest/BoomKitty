using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_line : MonoBehaviour
{
	Animator maattori;
    GameObject pelaaja;
	public static Vector2 playerPos;
    int countLines = 0;

    private LineRenderer [] lines;
    public float rateOfAttack = 0.5f;
	public float initialWait = 2f;
    public float waitTime = 2f;
    public GameObject lazerPosition;
    private Material [] materials;
    Material matToAssign;

    void Awake ()
    {
        pelaaja = GameObject.FindGameObjectWithTag("Player");
        lines = GetComponentsInChildren<LineRenderer>();
        materials = GetComponentInChildren<LineRenderer>().materials;
		maattori = GetComponentInChildren<Animator> ();

        foreach (LineRenderer rendo in lines)
        {
            rendo.enabled = false;
            rendo.material = materials [1];
        }
    }

    void OnEnable ()
    {
		InvokeRepeating("StartAttack", initialWait, rateOfAttack);
    }

    void StartAttack ()
    {
        if (countLines < lines.Length)
        {
			Invoke("Attack", waitTime);
			maattori.SetTrigger ("StartAttack");
        }

        else if (countLines == lines.Length)
        {
            Invoke("Hurt", waitTime);
			maattori.SetTrigger ("Attack");
        }

        else if (countLines > lines.Length)
        {
            Invoke("Disable", waitTime);
			maattori.SetTrigger ("BackToIdle");
        }
    }

    void Attack ()
    {
		playerPos = pelaaja.transform.position;
		lines [countLines].SetPosition (0, lazerPosition.transform.position);
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
