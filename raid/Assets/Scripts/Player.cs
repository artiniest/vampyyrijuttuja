using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour 
{
	public static int hitPoints = 100;
	public Text hpDisplay;

	void Update ()
	{
		hpDisplay.text = hitPoints.ToString();

		if (hitPoints <= 0) 
		{
			hitPoints = 0;
		}
	}
}
