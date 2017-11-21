using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_haldberd : Enemy
{
	public override void Start ()
	{
		base.Start ();
		dmg = 30;
		atkRate = 4;
		moveRate = 0.02f;

		InvokeRepeating ("Attack", 0, atkRate);
	}

	void Attack()
	{
		if (Vector2.Distance (transform.position, player.transform.position) <= 1.5)//&&playerdodges) 
		{
			Player2.hitPoints -= dmg;
			mator.SetTrigger("Attack");
		}
	}
}
