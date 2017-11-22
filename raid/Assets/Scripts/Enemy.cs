using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour 
{
	protected float dmg;
	protected int atkRate;
	protected float moveRate;
	protected float minDistance = 1.2f;

	protected GameObject player;
	protected Animator mator;
	protected SpriteRenderer rend;


	public virtual void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		rend = GetComponent<SpriteRenderer> ();
		mator = GetComponent<Animator>();
	}

	void Update ()
	{
		RaycastHit hit;

		if (Physics.Raycast (transform.position, player.transform.position - transform.position, out hit))
		{
			if (Vector2.Distance (player.transform.position, transform.position) >= minDistance && Player2.inShadows == false)
			//if (hit.collider.tag == "Player" && hit.distance >= minDistance && Player.isShadow == false)
			{
				if (hit.distance >= minDistance)
				{
					transform.position = Vector2.MoveTowards (transform.position, player.transform.position, 0.05f);
					transform.position = new Vector3 (transform.position.x, transform.position.y, -9);
					mator.SetBool ("seesPlayer", true);
				} else if (hit.distance <= minDistance)
				{
					mator.SetBool ("seesPlayer", false);
				}
			}
		}

		if (player.transform.position.x >= gameObject.transform.position.x) 
		{
			rend.flipX = true;

		} else {
			rend.flipX = false;
		}
	}
}
