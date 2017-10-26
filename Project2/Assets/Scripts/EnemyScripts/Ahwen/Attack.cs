using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour 
{
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
}
