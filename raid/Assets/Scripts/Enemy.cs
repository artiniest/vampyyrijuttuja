using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour 
{
	protected int dmg;
	protected int atkRate;
	protected float moveRate;
	protected float minDistance = 1.5f;

	protected GameObject player;
	protected Animator mator;
	protected SpriteRenderer rend;

	protected void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		rend = GetComponent<SpriteRenderer> ();
	}

	void Update ()
	{
		if (player.transform.position.x >= gameObject.transform.position.x) 
		{
			rend.flipX = true;

		} else {
			rend.flipX = false;
		}
	}

	protected void MoveTowards()
	{
		if (Vector2.Distance (transform.position, player.transform.position) >= minDistance) 
		{
			transform.position = Vector2.MoveTowards (transform.position, player.transform.position, 0.5f);
		}


	}
}
