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
	bool powerReady = false;
	public static bool isShadow = false;
	bool canMove = true;
	float atkTimer = 0f;

	GameObject[] enemies;

	void Start ()
	{
		controller = GetComponent<CharacterController> ();
		rendo = GetComponent<SpriteRenderer> ();
		maattori = GetComponent<Animator> ();

		StartCoroutine(GoInto());
	}

	void Update ()
	{
		enemies = GameObject.FindGameObjectsWithTag("Enemy");

		foreach (GameObject enemy in enemies)
		{
			if (isShadow == true)
			{
				Physics.IgnoreCollision (enemy.GetComponent<BoxCollider>(), controller, ignore: true);
			}

			else if (isShadow == false)
			{
				Physics.IgnoreCollision (enemy.GetComponent<BoxCollider>(), controller, ignore: false);
			}
		}

		if (canMove == true) 
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

		if (powerReady == false)
		{
			StartCoroutine(GoInto());
		}

		if (Input.GetKey (KeyCode.S) && powerReady == true)
		{
			StartCoroutine (ComeOut());
		}
	}

	public void CancelAttack()
	{
		attacked = false;
		maattori.SetBool ("ReadyAtk", false);
	}

	public void RegainControl ()
	{
		canMove = true;
	}

	IEnumerator GoInto ()
	{
			yield return new WaitForSeconds (powerWaitTime);
			print ("power ready");
			powerReady = true;
	}

	IEnumerator ComeOut()
	{
		if (powerReady == true)
		{
			maattori.SetBool ("Shadow", true);
			GetComponent<BoxCollider>().enabled = false;
			canMove = false;
			isShadow = true;

			yield return new WaitForSeconds (shadowTime);
			maattori.SetBool ("Shadow", false);
			powerReady = false;
			isShadow = false;
		}
	}

	IEnumerator OnTriggerStay (Collider other)
	{
		if (Input.GetKeyUp (KeyCode.E) && attacked == false && other.tag != "Player") 
		{
			yield return new WaitForSeconds (0.5f);
			Destroy (other.gameObject);
   		}
	}
}
