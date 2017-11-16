using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour 
{
	GameObject [] Enemies;

	public float WaitTime = 5;

	void Update()
	{
		Enemies = GameObject.FindGameObjectsWithTag ("Enemy");

		if (Enemies.Length == 0)
		{
			StartCoroutine(Spawn());
		}
	}

	IEnumerator Spawn()
	{
		yield return new WaitForSeconds (WaitTime);
		//Spawwwwwnwnwnwnwn
	}
}
