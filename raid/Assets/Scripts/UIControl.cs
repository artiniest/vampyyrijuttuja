using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour 
{
	public Text textext;
	public int levelToLoad = 0;
	public float letterRate = 0.15f;

	private string str;
	public string[] TextToAnimate;
	int nextLine = 0;

	void Start()
	{
		StartCoroutine(AnimateText(TextToAnimate[nextLine]));
	}

	void Update ()
	{
		textext.text = str;

		if (nextLine +1 == 4 && Player_tutorial.allowedToWalk == false)
		{
			Player_tutorial.allowedToWalk = true;
			StartCoroutine(Load());
		}

		else if (nextLine +1 == 5 && Player_tutorial.allowedToShadow == false)
		{
			Player_tutorial.allowedToWalk = true;
			Player_tutorial.allowedToShadow = true;
			StartCoroutine(Load());
		}

	}

	IEnumerator AnimateText(string strComplete)
	{
		yield return new WaitForSeconds (3);
		int i = 0;
		str = "";

		while(i < strComplete.Length)
		{
			str += strComplete[i++];
			yield return new WaitForSeconds(letterRate);
		}
		yield return new WaitForSeconds (0.5f);

		i = 0;

		if (nextLine +1 < TextToAnimate.Length)
		{
			nextLine ++;
			StartCoroutine(AnimateText(TextToAnimate[nextLine]));
		}
	}

	IEnumerator Load ()
	{
		yield return new WaitForSeconds (10);
		Application.LoadLevel(levelToLoad);
	}
}
