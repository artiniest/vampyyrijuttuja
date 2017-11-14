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

	public static bool attacked = false;

	void Start ()
	{
		controller = GetComponent<CharacterController> ();
		rendo = GetComponent<SpriteRenderer> ();
		maattori = GetComponent<Animator> ();
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
		}

		hpDisplay.text = hitPoints.ToString();

		if (moveDirection.x == 0) {
			maattori.SetBool ("Idle", true);
		} else {
			maattori.SetBool ("Idle", false);
		}

		if (Input.GetKey (KeyCode.D)) 
		{
			rendo.flipX = false;

		} else if (Input.GetKey (KeyCode.A)) 
		{
			rendo.flipX = true;
		}

		if (hitPoints <= 0) 
		{
			hitPoints = 0;
		}

		if (Input.GetKeyDown (KeyCode.E)) 
		{
			maattori.SetTrigger ("FastAttack");
			attacked = true;
		}
	}

	public void CancelAttack()
	{
		attacked = false;
	}

	IEnumerator OnTriggerStay (Collider other)
	{
		if (Input.GetKeyDown (KeyCode.E) && attacked == false) 
		{
			yield return new WaitForSeconds (0.25f);
			Destroy (other.gameObject);
		}
	}

}
