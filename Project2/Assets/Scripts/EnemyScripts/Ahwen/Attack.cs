using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour 
{
	public int healthPoints = 500;
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
        Bullet_pulsebubble.numObjects = 10;
        Bullet_pulsebubble.repeatRate = 1f;
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

	void OnTriggerEnter2D (Collider2D other) 
	{
		if (other.tag == "Bullet") 
		{
            source0.Play();
            Destroy(other.gameObject);
            healthPoints--;

            switch (healthPoints)
            {
                case 450:
                    Bullet_pulsebubble.numObjects = 15;
                    break;

                case 400:
                    Bullet_pulsebubble.numObjects = 20;
                    Bullet_pulsebubble.repeatRate = 0.9f;
                    break;

                case 300:
                    Bullet_pulsebubble.numObjects = 30;
                    source1.Play();
                    maattori.SetBool("hasTakenDmg", true);
                    break;

                case 250:
                    Bullet_pulsebubble.numObjects = 35;
                    Bullet_pulsebubble.repeatRate = 0.5f;
                    break;

                case 100:
                    source1.Stop();
                    maattori.SetBool("isThisHisFinalForm", true);
                    Bullet_pulsebubble.numObjects = 0;
                    Bullet_pulsebubble.repeatRate = 0;
                    healthPoints = 100;
                    break;
            }
		}
	}
}
