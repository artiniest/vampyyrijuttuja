﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour 
{
	public GameObject[] EnemyPrefabs;
	public Transform [] spawns;
	public GameObject [] Enemies;
	public GameObject player;
	public string sceneToLoad;

	bool introMovement = false;
	bool outroMovement = false;
	public bool hasBeenEnemies = false;

	void Start ()
	{
		StartCoroutine (StartAnimation());
	}

	void Update ()
	{
		Enemies = GameObject.FindGameObjectsWithTag ("Enemy");

		if (Enemies.Length > 0)
		{
			hasBeenEnemies = true;
		}

		if (introMovement == true)
		{
			player.transform.position = Vector2.MoveTowards(player.transform.position, new Vector2 (0, player.transform.position.y), 5f * Time.deltaTime);
		}

		if (outroMovement == true)
		{
			player.transform.Translate(new Vector2 (5 * Time.deltaTime, 0));
			//player.transform.position = Vector2.MoveTowards(player.transform.position, new Vector2 (9f, player.transform.position.y), 5f * Time.deltaTime);
		}

		if (player.transform.position.x == 0)
		{
			player.GetComponent<Animator>().SetBool ("Idle", true);
			introMovement = false;
			player.GetComponent<Player2>().enabled = true;
			Camera.main.GetComponent<CameraFollow>().enabled = true;
		}

		if (hasBeenEnemies == true && Enemies.Length < 1)
		{
			StartCoroutine (EndAnimation());
			hasBeenEnemies = false;
		}
	}

	IEnumerator StartAnimation ()
	{
		player.GetComponent<Player2>().enabled = false;
		Camera.main.GetComponent<CameraFollow>().enabled = false;
		yield return new WaitForSeconds (1);
		player.GetComponent<Animator>().SetBool("Idle", false);
		introMovement = true;
	}

	IEnumerator EndAnimation()
	{
		yield return new WaitForSeconds (1);
		player.GetComponent<Player2>().enabled = false;
		Camera.main.GetComponent<CameraFollow>().enabled = false;
		player.GetComponent<SpriteRenderer>().flipX = false;
		player.GetComponent<Animator>().SetBool("Idle", false);
		outroMovement = true;
		yield return new WaitForSeconds (2);
		UnityEngine.SceneManagement.SceneManager.LoadScene (sceneToLoad);
	}
}
