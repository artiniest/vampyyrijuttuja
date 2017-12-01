﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_torch : Enemy 
{
	public override void Start ()
	{
		base.Start ();
		dmg = 0.10f;
		atkRate = 0.5f;
		moveRate = 0.12f;

		InvokeRepeating ("Attack", 0, atkRate);
	}

	void Attack()
	{
		if (GetComponent<Animator>().GetBool("Dead") == false)
		{
			if (player != null && Vector2.Distance (transform.position, player.transform.position) <= 1.5f && Player2.inShadows == false)//&&playerdodges) 
			{
				mator.SetBool ("seesPlayer", false);
				mator.SetTrigger("Attack");
			}
		}
	}

	void Damage ()
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
