using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour 
{
	public GameObject[] EnemyPrefabs;
	public Transform [] spawns;
	public int amountToSpawn;
	public GameObject [] Enemies;

	public float StartWait = 2;
	public float spawnWait = 2;

	bool hasInvoked = false;
	int roundNbr = 0;

	void Update()
	{
		Enemies = GameObject.FindGameObjectsWithTag ("Enemy");

		if (Enemies.Length == 0 && hasInvoked == false)
		{
			RoundManager();
		}
	}

	IEnumerator RoundManager ()
	{
		yield return new WaitForSeconds (1);

		switch (roundNbr)
		{
		case 0: 
			hasInvoked = true;
			amountToSpawn = 2;
			StartCoroutine (Spawn());
			break;
		case 1: 
			hasInvoked = true;
			amountToSpawn = 5;
			StartCoroutine (Spawn());
			break;
		case 2: 
			hasInvoked = true;
			amountToSpawn = 8;
			StartCoroutine(Spawn());
			break;
		}
	}

	IEnumerator Spawn()
	{
		while (Enemies.Length < amountToSpawn)
		{
			yield return new WaitForSeconds (StartWait);
			GameObject enemy = Instantiate (EnemyPrefabs[Random.Range(0, EnemyPrefabs.Length)], spawns[Random.Range(0, spawns.Length)]);
			enemy.transform.parent = null;
		}
		yield return new WaitForSeconds (spawnWait);
		roundNbr += 1;
		hasInvoked = false;
	}
}
