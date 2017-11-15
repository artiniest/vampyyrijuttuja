using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour 
{
	public static int hitPoints = 100;
	public Text hpDisplay;
	CharacterController controller;
	SpriteRenderer rendo;
	Animator maattori;
	private Vector2 moveDirection = Vector2.zero;
	public float moveSpeed = 10f;
	public float gravity = 20f;
	public float powerWaitTime = 2;
	public float shadowTime = 2f;

	public static bool attacked = false;
	bool shadowReady = false;
	float atkTimer = 0f;

	void Start ()
	{
		controller = GetComponent<CharacterController> ();
		rendo = GetComponent<SpriteRenderer> ();
		maattori = GetComponent<Animator> ();

		StartCoroutine(GoInto());
	}

	void Update ()
	{
		if (attacked == false) 
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
		}

		if (hpDisplay != null)
		{
			hpDisplay.text = hitPoints.ToString();
		}

		if (moveDirection.x == 0) {
			maattori.SetBool ("Idle", true);
		} else {
			maattori.SetBool ("Idle", false);
		}

		if (hitPoints <= 0) 
		{
			hitPoints = 0;
		}

		if (Input.GetKey (KeyCode.E)) {
			maattori.SetBool ("ReadyAtk", true);
			atkTimer += 2 * Time.deltaTime;
		} 

		else if (atkTimer > 1 && Input.GetKeyUp (KeyCode.E)) 
		{
			maattori.SetTrigger ("HeavyAttack");
			attacked = true;
			atkTimer = 0;
		} 

		else if (atkTimer < 1 && Input.GetKeyUp (KeyCode.E)) 
		{
			maattori.SetTrigger ("FastAttack");
			attacked = true;
			atkTimer = 0;
		}

		if (Input.GetKey (KeyCode.S) && shadowReady == true)
		{
			StartCoroutine (ComeOut());
		}
	}

	public void CancelAttack()
	{
		attacked = false;
		maattori.SetBool ("ReadyAtk", false);
	}

	IEnumerator GoInto ()
	{
		if (shadowReady == false)
		{
			yield return new WaitForSeconds (powerWaitTime);
			print ("power ready");
			shadowReady = true;
		}
	}

	IEnumerator ComeOut()
	{
		if (shadowReady == true)
		{
			maattori.SetBool ("Shadow", true);
			yield return new WaitForSeconds (shadowTime);
			print ("power used");
			maattori.SetBool ("Shadow", false);
			shadowReady = false;
		}
	}

	/*IEnumerator OnTriggerStay (Collider other)
	{
		if (Input.GetKeyDown (KeyCode.E) && attacked == false) 
		{
			yield return new WaitForSeconds (0.25f);
			Destroy (other.gameObject);
		}
	}*/

}
