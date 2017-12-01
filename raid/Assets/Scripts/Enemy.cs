using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour 
{
	protected float dmg;
	protected float atkRate;
	protected float moveRate = 0.07f;
	protected float minDistance = 1.2f;
	protected float maxDistance = 10f;

	protected GameObject player;
	protected Animator mator;
	protected SpriteRenderer rend;
	protected AudioSource enemyHit;

	public virtual void Start ()
	{
		rend = GetComponent<SpriteRenderer> ();
		mator = GetComponent<Animator>();
		enemyHit = GetComponent<AudioSource>();
		StartCoroutine(FindPlayer());
	}

	void Update ()
	{
		if (player == null)
		{
			StartCoroutine (FindPlayer());
		}

		RaycastHit hit;

		if (player != null && Physics.Raycast (transform.position, player.transform.position - transform.position, out hit) && mator.GetBool("Dead") == false)
		{
			if (Vector2.Distance (player.transform.position, transform.position) >= minDistance && Vector2.Distance (player.transform.position, transform.position) <= maxDistance && Player2.inShadows == false)
			{
				if (hit.distance >= minDistance)
				{
					transform.position = Vector2.MoveTowards (transform.position, player.transform.position, moveRate);
					mator.SetBool ("seesPlayer", true);
				} else if (hit.distance <= minDistance)
				{
					mator.SetBool ("seesPlayer", false);
				}
			}
		}

		if (player != null && player.transform.position.x >= gameObject.transform.position.x) 
		{
			rend.flipX = true;

		} else {
			rend.flipX = false;
		}
	}

	IEnumerator FindPlayer()
	{
		yield return new WaitForSeconds(0.5f);
		player = GameObject.FindGameObjectWithTag ("Player");
	}
}
