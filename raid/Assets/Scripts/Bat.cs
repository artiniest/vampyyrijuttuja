using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour 
{
	public GameObject bat;
	public GameObject[] Points;
	int nextPoint = 0;

	bool spawned = false;

	void Update ()
	{
		if (spawned == true)
		{
			bat.transform.position = Vector2.MoveTowards(bat.transform.position, Points[nextPoint].transform.position, 0.07f);

			if (bat.transform.position == Points[nextPoint].transform.position && nextPoint < Points.Length -1)
			{
				nextPoint ++;
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		spawned = true;
	}
}
