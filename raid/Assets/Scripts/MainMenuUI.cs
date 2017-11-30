using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour 
{
	public void StartGame ()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Intro");
	}

	public void Tutorial()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Tutorial");
	}
}
