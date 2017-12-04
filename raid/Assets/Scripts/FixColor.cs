using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FixColor : MonoBehaviour 
{
	public Color topColor;
	public Color middleColor;
	public Color botColor;

	Color outputColor;
	public Text thisText;

	float time = 0f;
	float duration = 10;

	void Start()
	{
		thisText = GetComponent<Text>();
	}

	void Update()
	{
		if (IntroCam.moveCam == true)
		{
			if (time < 0.50f)
			{
				outputColor = Color.Lerp(botColor, middleColor, time);
			} else {
				outputColor = Color.Lerp(middleColor, topColor, time);
			}

			thisText.color = outputColor;

			if (time < 1)
			{
				time += Time.deltaTime/duration;
			}
		}
	}
}
