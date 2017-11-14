using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
	public int health = 1;
	protected int dmg = 1;
	protected int atkRate = 1;
	protected float moveRate = 2;
	protected float minDistance = 1.5f;

	protected GameObject player;
	public Animator mator;

	protected void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	protected void MoveTowards()
	{
		if (Vector2.Distance (transform.position, player.transform.position) >= minDistance) 
		{
			transform.position = Vector2.MoveTowards (transform.position, player.transform.position, 0.5f);
		}
	}

	void OnTriggerStay (Collider other)
	{
		if (other.tag == "Player" && Player.attacked == true) 
		{
			TakeDmg ();
		}
	}

	protected void TakeDmg()
	{
		health --;

		if (health < 1) 
		{
			Invoke ("Die", 0f);
		}
	}

	protected void Die ()
	{
		//käynnistä animaatio jne
		Destroy (this.gameObject);
	}
}
