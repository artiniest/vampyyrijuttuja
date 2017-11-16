using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour 
{
	protected int dmg;
	protected int atkRate;
	protected float moveRate;
	protected float minDistance = 2f;

	protected GameObject player;
	protected Animator mator;
	protected SpriteRenderer rend;

	protected void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		rend = GetComponent<SpriteRenderer> ();
		mator = GetComponent<Animator>();
	}

	void Update ()
	{
		if (Vector2.Distance (transform.position, player.transform.position) >= minDistance && Player.isShadow == false) 
		{
			transform.position = Vector2.MoveTowards (transform.position, player.transform.position, 0.05f);
			mator.SetBool ("seesPlayer", true);
		} else if (Player.isShadow == true){
			mator.SetBool ("seesPlayer", false);
		} else if (Vector2.Distance (transform.position, player.transform.position) <= minDistance){
			mator.SetBool ("seesPlayer", false);
		}

		if (player.transform.position.x >= gameObject.transform.position.x) 
		{
			rend.flipX = true;

		} else {
			rend.flipX = false;
		}
	}
}
