using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2 : MonoBehaviour 
{
	//Things to get
	public Animator maattori;
	public CharacterController controller;
	public SpriteRenderer rendo;
	public GameObject Rune;
	public BoxCollider wpnColl;
	public GameObject healthBar;
	public AudioSource sourssi;
	public AudioSource enemyHit;

	//Moving stuffs
	bool canMove = true;
	public float moveSpeed = 10f;
	public float gravity = 20f;
	Vector2 moveDirection = Vector2.zero;

	//Shadowstuff
	public float shadowWaitTime = 2f;
	public float shadowTime = 2f;
	bool shadowReady = false;
	public static bool inShadows = false;
	GameObject[] enemies;

	//Attacking things
	public static float hitPoints = 1f;
	float atkTimer = 0f;

	//Varjo

	//Hyökkäys

	void Update ()
	{
		if (healthBar != null)
		{
			healthBar.transform.localScale = new Vector2 (hitPoints, healthBar.transform.localScale.y);

			if (healthBar.transform.localScale.x <= 0)
			{
				healthBar.transform.localScale = new Vector2 (0, healthBar.transform.localScale.y);
			}
		}

		//Movement things
		if (canMove == true)
		{
			moveDirection = new Vector2 (Input.GetAxis ("Horizontal"), 0);
			moveDirection = transform.TransformDirection (moveDirection);
			moveDirection *= moveSpeed;
			moveDirection.y -= gravity * Time.deltaTime;
			controller.Move (moveDirection);

			if (Input.GetKeyDown(KeyCode.D))
			{
				rendo.flipX = false;
			} else if (Input.GetKeyDown(KeyCode.A)){
				rendo.flipX = true;
			}

			if (moveDirection.x == 0)
			{
				maattori.SetBool("Idle", true);
			} else {
				maattori.SetBool ("Idle", false);
			}

		}

		//Shadow things
		if (shadowReady == false)
		{
			StartCoroutine(ShadowRecharge());
		}

		if (shadowReady == true && Input.GetKeyDown(KeyCode.S))
		{
			StartCoroutine(Shadow());
		}
		enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		foreach (GameObject enemy in enemies)
		{
			if (inShadows == true)
			{
				Physics.IgnoreCollision (controller, enemy.GetComponent<BoxCollider>(), ignore: true);

			} else {

				Physics.IgnoreCollision (controller, enemy.GetComponent<BoxCollider>(), ignore: false);
			}
		}

		//Attack things
		if (Input.GetKey(KeyCode.E))
		{
			canMove = false;
			maattori.SetBool ("ReadyAtk", true);
			atkTimer += 2 * Time.deltaTime;
		} else if (atkTimer > 1 && Input.GetKeyUp(KeyCode.E))
		{
			canMove = false;
			maattori.SetTrigger("HeavyAttack");
			atkTimer = 0;

			if (rendo.flipX == false)
			{
				wpnColl.enabled = true;
				wpnColl.size = new Vector2(3.5f, wpnColl.size.y);
				wpnColl.center = new Vector2 (1.5f, wpnColl.center.y);
			} else if (rendo.flipX == true)
			{
				wpnColl.enabled = true;
				wpnColl.size = new Vector2(3.5f, wpnColl.size.y);
				wpnColl.center = new Vector2 (-1.5f, wpnColl.center.y);

			}
		} else if (atkTimer < 1 && Input.GetKeyUp(KeyCode.E))
		{
			canMove = false;
			maattori.SetTrigger("FastAttack");
			atkTimer = 0;

			if (rendo.flipX == false)
			{
				wpnColl.enabled = true;
				wpnColl.size = new Vector2(1.5f, wpnColl.size.y);
				wpnColl.center = new Vector2 (0.75f, wpnColl.center.y);
			} else if (rendo.flipX == true)
			{
				wpnColl.enabled = true;
				wpnColl.size = new Vector2(1.5f, wpnColl.size.y);
				wpnColl.center = new Vector2 (-0.75f, wpnColl.center.y);
			}
		}
	}

	IEnumerator ShadowRecharge()
	{
		yield return new WaitForSeconds (shadowWaitTime);
		shadowReady = true;
		Rune.GetComponent<Animator>().SetBool("isLit", true);
	}

	IEnumerator Shadow()
	{
		maattori.SetBool ("Shadow", true);
		canMove = false;
		inShadows = true;
		moveSpeed = 0.2f;
		yield return new WaitForSeconds (shadowTime);
		maattori.SetBool("Shadow", false);
		shadowReady = false;
		inShadows = false;
		moveSpeed = 0.1f;
		Rune.GetComponent<Animator>().SetBool("isLit", false);
	}

	IEnumerator OnTriggerEnter (Collider other)
	{
		if (other.tag == "Enemy" && inShadows == false)
		{
			yield return new WaitForSeconds (0.2f);
			other.GetComponent<AudioSource>().Play();
			yield return new WaitForSeconds (0.2f);
			Destroy (other.gameObject);
		}
	}

	public void RegainControl ()
	{
		canMove = true;
	}

	public void CancelAttack ()
	{
		canMove = true;
		maattori.SetBool("ReadyAtk", false);
		wpnColl.enabled = false;
	}

	public void PlaySound()
	{
		sourssi.Play();
	}
}
