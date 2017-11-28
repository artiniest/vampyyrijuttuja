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
		moveRate = 0.01f;

		InvokeRepeating ("Attack", 0, atkRate);
	}

	void Attack()
	{
		if (player != null && Vector2.Distance (transform.position, player.transform.position) <= 1.5f && Player2.inShadows == false)//&&playerdodges) 
		{
			mator.SetTrigger("Attack");
			CameraFollow.shakeDuration += 0.5f;
			Player2.hitPoints -= dmg;
			GetComponent<AudioSource>().Play();
		}
	}

	void PlaySound()
	{
		GetComponent<AudioSource>().Play();
	}
}
