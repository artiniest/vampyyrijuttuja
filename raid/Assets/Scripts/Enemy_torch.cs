using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_torch : Enemy 
{
	void Start ()
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
			Player.hitPoints -= dmg;
			mator.SetTrigger("Attack");
		}
	}
}
