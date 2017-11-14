using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
	protected int dmg;
	protected int atkRate;
	protected float moveRate;
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
}
