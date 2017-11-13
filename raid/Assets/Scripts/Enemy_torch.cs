using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_torch : Enemy 
{
	void Start ()
	{
		base.Start ();
		health = 3;
		dmg = 1;
		atkRate = 1;
		moveRate = 0.25f;

		InvokeRepeating ("MoveTowards", 1f, moveRate);
		InvokeRepeating ("Attack", 0, atkRate);
	}

	void Attack()
	{
		if (Vector2.Distance (transform.position, player.transform.position) <= minDistance)//&&playerdodges) 
		{
			Player.hitPoints -=dmg;
		}
	}
}
