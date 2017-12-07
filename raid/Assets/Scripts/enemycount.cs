using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemycount : MonoBehaviour 
{
	public Sprite[] sprites;
	public SpriteRenderer[] counts;
	public static int ticker = 2;
	public int activeIndicatorsMinusOne;

	void Update ()
	{
		if (ticker < 0 && activeIndicatorsMinusOne != -1)
		{
			counts[activeIndicatorsMinusOne].enabled = false;
			ticker = 4;
			activeIndicatorsMinusOne--;
		} 


		if (activeIndicatorsMinusOne > -1)
		{
			counts[activeIndicatorsMinusOne].sprite = sprites[ticker];
		}
	}

	public static void OneLess ()
	{
		ticker --;
	}
}
