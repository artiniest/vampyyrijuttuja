using System.Collections;
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

	void Damage ()
	{
		CameraFollow.shakeDuration += 0.5f;
		Player2.hitPoints -= dmg;
		sourse.Play();
	}

	void Death ()
	{
		enemycount.OneLess();
		Destroy (this.gameObject);
	}
}
