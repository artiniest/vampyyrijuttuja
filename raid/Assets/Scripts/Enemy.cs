using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
	protected int health = 1;
	protected int dmg = 1;
	protected float moveRate = 2;
	protected float minDistance = 1.5f;

	public GameObject player;
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

	protected void Attack ()
	{
		//Attack
	}

	protected void TakeDmg()
	{
		health -= 1;

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
