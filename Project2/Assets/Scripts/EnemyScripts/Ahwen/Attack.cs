using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour 
{
	public int healthPoints = 3000;
    public int secondForm = 2950;
    public int finalForm = 2000;
	public Animator maattori;
    public AudioSource [] sources;
    AudioSource source0;
    AudioSource source1;

	void Start ()
	{
		maattori = GetComponent<Animator> ();
        sources = GetComponents<AudioSource>();
        source0 = sources [0];
        source1 = sources [1];
	}

	void Update ()
	{
		if (healthPoints < secondForm) 
		{
			maattori.SetBool ("hasTakenDmg", true);
		}

		if (healthPoints < finalForm) 
		{
			maattori.SetBool ("isThisHisFinalForm", true);
		}
	}

	void SMALLSHAKE ()
	{
		ShakeScreen.shakeAmount = 0.1f;
		ShakeScreen.shakeDuration = 2f;
	}

	void MEDIUMSHAKE ()
	{
		ShakeScreen.shakeAmount = 0.2f;
		ShakeScreen.shakeDuration = 2f;
	}

	void BIGSHAKE ()
	{
		ShakeScreen.shakeAmount = 0.7f;
		ShakeScreen.shakeDuration = 5;
	}

    void LaughAway ()
    {
        source1.Play();
    }

	void OnTriggerStay2D (Collider2D other) 
	{
		if (other.tag == "Bullet") 
		{
            if (healthPoints < secondForm)
            {
                source1.Play();
            }
            source0.Play();
            Destroy(other.gameObject);
			healthPoints--;
		}
	}
}
