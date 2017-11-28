using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enem_boss : Enemy 
{
	int hitPoints = 100;

	public override void Start ()
	{
		base.Start ();
		dmg = 0.20f;
		atkRate = 3;
		moveRate = 0.007f;
		minDistance = 2.5f;

		InvokeRepeating ("Attack", 0, atkRate);
	}

	void Attack()
	{
		if (player != null && Vector2.Distance (transform.position, player.transform.position) <= 2.5f)//&&playerdodges) 
		{
			CameraFollow.shakeDuration += 0.5f;
			Player2.hitPoints -= dmg;
			mator.SetTrigger("Attack");
		}
	}
}
