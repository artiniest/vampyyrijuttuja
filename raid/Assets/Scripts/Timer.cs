using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour 
{
	public float WaitTime = 1f;
	public GameObject EnemyToDisable;
	GameObject player;

	void Start ()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		EnemyToDisable.SetActive (false);
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player")
		{
			StartCoroutine (Enable());
		}
	}

	IEnumerator Enable ()
	{
		yield return new WaitForSeconds (WaitTime);

		bool didItHappen = false;
		if (EnemyToDisable != null && Vector2.Distance (transform.position, player.transform.position) > 8f)
		{
			EnemyToDisable.SetActive (true);
			didItHappen = true;
		}

		if (didItHappen == false)
		{
			StartCoroutine(Enable());
		}
	}
}
