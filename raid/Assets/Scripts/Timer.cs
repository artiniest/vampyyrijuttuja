using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour 
{
	public float WaitTime = 1f;
	GameObject player;
	GameObject childo;

	void Start ()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		childo = transform.GetChild(0).gameObject;
		childo.SetActive(false);
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
		if (Vector2.Distance (transform.position, player.transform.position) > 8f)
		{
			childo.SetActive (true);
			didItHappen = true;
			childo.transform.SetParent(null);
			Destroy (this.gameObject);
		}

		if (didItHappen == false)
		{
			StartCoroutine(Enable());
		}
	}
}
