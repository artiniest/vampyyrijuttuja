using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_torch : Enemy 
{
	public override void Start ()
	{
		base.Start ();
		dmg = 10;
		atkRate = 1;
		moveRate = 0.25f;

		InvokeRepeating ("Attack", 0, atkRate);
	}

	void Attack()
	{
		if (Vector2.Distance (transform.position, player.transform.position) <= 1.5)//&&playerdodges) 
		{
			CameraFollow.shakeDuration += 0.5f;
			Player2.hitPoints -= dmg;
			mator.SetTrigger("Attack");
		}
	}
}
