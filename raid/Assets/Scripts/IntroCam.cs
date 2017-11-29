using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroCam : MonoBehaviour 
{
	public Text intoText;
	public string levelToLoad;
	float letterRate = 0.05f;

	private string str;
	public string [] TextToAnimate;
	int nextLine = 0;
	bool moveCam = false;
	bool secondAnim = false;

	void Start () 
	{
		StartCoroutine (Animation(TextToAnimate[nextLine]));
	}

	void Update()
	{
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

		intoText.text = str;
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
		yield return new WaitForSeconds (3);
		print ("inner monologue?");
	}
}
