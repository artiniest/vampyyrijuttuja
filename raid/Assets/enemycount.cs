using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemycount : MonoBehaviour 
{
	public Sprite[] sprites;
	SpriteRenderer rendo;
	int enemyCount;

	void Start ()
	{
		rendo = GetComponentInChildren<SpriteRenderer>();
	}

	void Update ()
	{
		//enemyCount = Player2.enemies.Length;

		switch (enemyCount)
		{
		case 1:
			rendo.sprite = sprites[0];
			break;
		case 2:
			rendo.sprite = sprites[1];
			break;
		case 3:
			rendo.sprite = sprites[2];
			break;
		case 4:
			rendo.sprite = sprites[3];
			break;
		case 5:
			rendo.sprite = sprites[4];
			break;
		}
	}
}
