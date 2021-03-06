﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroCam : MonoBehaviour 
{
	public Text intoText;
	public GameObject player;
	public string levelToLoad;
	float letterRate = 0.05f;

	private string str;
	public string [] TextToAnimate;
	int nextLine = 0;
	public static bool moveCam = false;
	bool secondAnim = false;

	void Start () 
	{
		StartCoroutine (Animation(TextToAnimate[nextLine]));
	}

	void Update()
	{
        if (Input.GetKeyDown (KeyCode.L))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene (levelToLoad);
        }

		intoText.text = str;

		if (moveCam == true && transform.position.y > 0.5f)
		{
			transform.Translate (Vector2.MoveTowards (new Vector2 (0,0), transform.position, -2f * Time.deltaTime));
		}

		else if (transform.position.y < 1 && secondAnim == false)
		{
			secondAnim = true;
			intoText.text = "";
			StartCoroutine (Animation2());
		}
	}

	IEnumerator Animation (string strComplete)
	{
		yield return new WaitForSeconds (1.5f);
		int i = 0;
		str = "";

		while (i < strComplete.Length)
		{
			str += strComplete[i++];
			yield return new WaitForSeconds (letterRate);
		}
		yield return new WaitForSeconds (1);

		i = 0;

		if (nextLine +1 < TextToAnimate.Length)
		{
			nextLine ++;
			StartCoroutine(Animation(TextToAnimate[nextLine]));
		}

		moveCam = true;
	}

	IEnumerator Animation2 ()
	{
		yield return new WaitForSeconds (3f);
		intoText.enabled = false;
		yield return new WaitForSeconds (1.5f);
		player.GetComponent<Animator>().SetTrigger("Walk");
		yield return new WaitForSeconds(2);
		player.SetActive (false);
		UnityEngine.SceneManagement.SceneManager.LoadScene (levelToLoad);
	}
}

