using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_pitchfork : Enemy 
{
	void Start ()
	{
		base.Start ();
		dmg = 30;
		atkRate = 3;
		moveRate = 0.01f;

		InvokeRepeating ("Attack", 0, atkRate);
	}

	void Attack()
	{
		if (Vector2.Distance (transform.position, player.transform.position) <= minDistance)//&&playerdodges) 
		{
			CameraShake.shakeDuration = 0.25f;
			Player.hitPoints -= dmg;
			mator.SetTrigger("Attack");
		}
	}
}
