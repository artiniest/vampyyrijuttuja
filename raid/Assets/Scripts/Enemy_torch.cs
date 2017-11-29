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
		moveRate = 0.25f;

		InvokeRepeating ("Attack", 0, atkRate);
	}

	void Attack()
	{
		if (player != null && Vector2.Distance (transform.position, player.transform.position) <= 1.5f && Player2.inShadows == false)//&&playerdodges) 
		{
			mator.SetBool ("seesPlayer", false);
			mator.SetTrigger("Attack");
			CameraFollow.shakeDuration += 0.5f;
			Player2.hitPoints -= dmg;
			GetComponent<AudioSource>().Play();
		}
	}

	void PlaySound()
	{
		GetComponent<AudioSource>().Play();
	}

	void Death ()
	{
		Destroy (this.gameObject);
	}
}
