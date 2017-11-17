using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_tutorial : MonoBehaviour 
{
	CharacterController controller;
	Animator mator;
	Vector2 moveDirection = Vector2.zero;
	SpriteRenderer rendo;

	public float moveSpeed = 10f;
	public float gravity = 20f;
	public static bool allowedToWalk = false;
	public static bool allowedToShadow = false;
	bool canMove = true;
	bool powerReady = false;
	bool isShadow = false;

	void Start () 
	{
		controller = GetComponent<CharacterController>();
		rendo = GetComponent<SpriteRenderer>();
		mator = GetComponent<Animator>();
	}

	void Update () 
	{
		if (allowedToWalk == true) 
		{
			moveDirection = new Vector2 (Input.GetAxis ("Horizontal"), 0);
			moveDirection = transform.TransformDirection (moveDirection);
			moveDirection *= moveSpeed;

			moveDirection.y -= gravity * Time.deltaTime;
			controller.Move (moveDirection);

			if (Input.GetKey (KeyCode.D)) 
			{
				rendo.flipX = false;

			} else if (Input.GetKey (KeyCode.A)) 
			{
				rendo.flipX = true;
			}

			if (moveDirection.x == 0) {
				mator.SetBool ("Idle", true);
			} else {
				mator.SetBool ("Idle", false);
			}
		}

		if (allowedToShadow == true)
		{
			if (powerReady == false)
			{
				StartCoroutine(GainPower());
			}

			if (Input.GetKey (KeyCode.S) && powerReady == true)
			{
				StartCoroutine (ComeOut());
			}
		}
	}

	public void RegainControl ()
	{
		canMove = true;
	}

	IEnumerator GainPower ()
	{
		yield return new WaitForSeconds (2f);
		print ("power ready");
		powerReady = true;
	}

	IEnumerator ComeOut()
	{
		print ("shadow");
		if (powerReady == true)
		{
			mator.SetBool ("Shadow", true);
			canMove = false;
			isShadow = true;

			yield return new WaitForSeconds (5);
			mator.SetBool ("Shadow", false);
			powerReady = false;
			isShadow = false;
		}
	}
}
