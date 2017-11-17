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
	public float spawnWait = 1;

	bool hasInvoked = false;

	void Update()
	{
		Enemies = GameObject.FindGameObjectsWithTag ("Enemy");

		if (Enemies.Length < amountToSpawn && hasInvoked == false)
		{
			StartCoroutine (Spawn());
			//Invoke ("Spawn", 1);
		}
	}

	IEnumerator Spawn()
	{
		hasInvoked = true;
		yield return new WaitForSeconds (StartWait);
		GameObject enemy = Instantiate (EnemyPrefabs[Random.Range(0, EnemyPrefabs.Length)], spawns[Random.Range(0, spawns.Length)]);
		enemy.transform.parent = null;
		yield return new WaitForSeconds (spawnWait);
		hasInvoked = false;
	}
}
