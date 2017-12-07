using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enem_boss : Enemy 
{
	public static int hitPoints = 100;

	public override void Start ()
	{
		base.Start ();
		dmg = 0.15f;
		atkRate = 3;
		moveRate = 0.07f;
		minDistance = 2.5f;

		InvokeRepeating ("AttackBoss", 0, atkRate);
	}

	void AttackBoss()
	{
		if (mator.GetBool("Dead") == false)
		{
			if (player != null && Vector2.Distance (transform.position, player.transform.position) <= minDistance + 1 && Player2.inShadows == false)
			{
				mator.SetTrigger("Attack");
				mator.SetBool("seesPlayer", false);
			}
		}
	}

	void Damage ()
	{
		CameraFollow.shakeDuration += 0.5f;
		Player2.hitPoints -= dmg;
		sourse.Play();
	}

	void PlaySound()
	{
		sourse.Play();
	}

	void EpicDeath()
	{
		CameraFollow.shakeDuration += 2f;
		GetComponent<BoxCollider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
	}

	void Die()
	{
		Destroy (this.gameObject);
	}
}
