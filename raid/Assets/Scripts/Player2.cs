﻿using System.Collections;
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
	public GameObject[] enemies;

	//Attacking things
	public static float hitPoints = 1f;
	float atkTimer = 0f;

	//Varjo

	//Hyökkäys

	void Start ()
	{
		if (hitPoints < 0.001f)
		{
			hitPoints = 1;
		}

		CameraFollow.shakeDuration = 0;

		canMove = true;
		inShadows = false;
	
	}

	void Update ()
	{
        if (Input.GetKeyDown(KeyCode.H))
            {
                hitPoints = 1;
            }
        if (Input.GetKeyDown(KeyCode.L))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(SceneManag.publicScene);
            }

		if (hitPoints < 0.01f)
		{
			maattori.SetBool("Dead", true);
			canMove = false;
			inShadows = true;
		}

		//Movement things
		if (canMove == true)
		{
			moveDirection = new Vector2 (Input.GetAxis ("Horizontal"), 0);
			moveDirection = transform.TransformDirection (moveDirection);
			moveDirection *= moveSpeed;
			moveDirection.y -= gravity * Time.deltaTime;
			controller.Move (moveDirection);

			if (moveDirection.x > 0)
			{
				rendo.flipX = false;
			} else if (moveDirection.x < 0){
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

		if (enemies.Length == 0)
		{
			enemies = GameObject.FindGameObjectsWithTag ("EnemyBoss");
		}

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
				wpnColl.size = new Vector2(3.5f, wpnColl.size.y);
				wpnColl.center = new Vector2 (1.5f, wpnColl.center.y);
			} else if (rendo.flipX == true)
			{
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
				wpnColl.size = new Vector2(1.5f, wpnColl.size.y);
				wpnColl.center = new Vector2 (0.75f, wpnColl.center.y);
			} else if (rendo.flipX == true)
			{
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

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Enemy" && inShadows == false && other.GetComponent<Enem_boss>() != null)
		{
            other.GetComponent<AudioSource>().Play();
            Enem_boss.hitPoints -= 10;

            if (Enem_boss.hitPoints < 1)
            {
                other.GetComponent<Animator>().SetBool("Dead", true);
            }
        }

		else if (other.tag == "Enemy" && inShadows == false && other.GetComponent<Enem_boss>() == null)
		{
            other.GetComponent<AudioSource>().Play();
            other.GetComponent<Animator>().SetBool("Dead", true);
            other.GetComponent<Enemy>().enabled = false;
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

	public void Attacks()
	{
		wpnColl.enabled = true;
	}

	void DeadScene ()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
	}
}
