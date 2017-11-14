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
		moveRate = 1;

		InvokeRepeating ("MoveTowards", 1f, moveRate);
		InvokeRepeating ("Attack", 0, atkRate);
	}
	void Attack()
	{
		if (Vector2.Distance (transform.position, player.transform.position) <= minDistance)//&&playerdodges) 
		{
			Player.hitPoints -= dmg;
		}
	}
}
