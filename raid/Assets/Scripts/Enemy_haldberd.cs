using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_haldberd : Enemy
{
	public override void Start ()
	{
		base.Start ();
		dmg = 0.30f;
		atkRate = 2;
		moveRate = 0.05f;

		InvokeRepeating ("Attack", 0, atkRate);
	}

	void Damage()
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
