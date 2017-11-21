using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour 
{
	public Text hpDisplay;
	public Text scoreDisplay;
	public GameObject ShadowRune;
	public float moveSpeed = 10f;
	public float gravity = 20f;
	public float powerWaitTime = 2;
	public float shadowTime = 2f;
	public float minEnemyDistance = 1.1f;
	public static int hitPoints = 100;

	public static bool attacked = false;
	public static bool isShadow = false;

	Animator maattori;
	bool powerReady = false;
	bool canMove = true;
	CharacterController controller;
	float atkTimer = 0f;
	GameObject[] enemies;
	int killScore = 0;
	private Vector2 moveDirection = Vector2.zero;
	SpriteRenderer rendo;
	RaycastHit hit;

	void Start ()
	{
		controller = GetComponent<CharacterController> ();
		rendo = GetComponent<SpriteRenderer> ();
		maattori = GetComponent<Animator> ();

		StartCoroutine(GoInto());
	}

	void Update ()
	{
		if (powerReady == false)
		{
			ShadowRune.GetComponent<Animator>().SetBool("isLit", false);
		}

		else if (powerReady == true)
		{
			ShadowRune.GetComponent<Animator>().SetBool("isLit", true);
		}

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
				if (Physics.Raycast(transform.position, Vector2.right, out hit))
				{
					Debug.DrawRay(transform.position, Vector2.right, Color.white, 1);
					print (hit.collider.name);
				}
				rendo.flipX = false;

			} else if (Input.GetKey (KeyCode.A)) 
			{
				if (Physics.Raycast(transform.position, Vector2.left, out hit))
				{
					Debug.DrawRay(transform.position, Vector2.left, Color.white, 1);
					print (hit.collider.name);
				}
				rendo.flipX = true;
			}
		}

		if (hpDisplay != null)
		{
			hpDisplay.text = hitPoints.ToString();
		}

		if (scoreDisplay != null)
		{
			scoreDisplay.text = killScore.ToString();
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
			minEnemyDistance = 4;
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

//		if (Physics.Raycast(transform.position, Vector2.right) || Physics.Raycast(transform.position, Vector2.left) && Input.GetKeyDo (KeyCode.E)) 
		{
			StartCoroutine(Kill());
		}
	}

	IEnumerator Kill ()
	{
		if (Physics.Raycast(transform.position, Vector2.right) || Physics.Raycast(transform.position, Vector2.left) && Vector2.Distance (transform.position, hit.collider.transform.position) <= minEnemyDistance)
		{
			yield return new WaitForSeconds (0.5f);
			hit.collider.gameObject.SetActive(false);
			killScore ++;
		}
	}

	public void CancelAttack()
	{
		attacked = false;
		maattori.SetBool ("ReadyAtk", false);
	}

	/*public void RegainControl ()
	{
		canMove = true;
	}*/

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
			canMove = false;
			isShadow = true;

			yield return new WaitForSeconds (shadowTime);
			maattori.SetBool ("Shadow", false);
			powerReady = false;
			isShadow = false;
		}
	}
}
