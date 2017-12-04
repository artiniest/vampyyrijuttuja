﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_pitchfork : Enemy 
{
	public override void Start ()
	{
		base.Start ();
		dmg = 0.20f;
		atkRate = 1.5f;
		moveRate = 0.05f;

		InvokeRepeating ("Attack", 0, atkRate);
	}

	void Damage()
	{
		CameraFollow.shakeDuration += 0.5f;
		Player2.hitPoints -= dmg;
		GetComponent<AudioSource>().Play();
	}

	void Death ()
	{
		Destroy (this.gameObject);
	}
}
