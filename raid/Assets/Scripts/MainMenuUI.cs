using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour 
{
    public GameObject creds;

	public void StartGame ()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Intro");
	}

	public void EnableCreds()
	{
        if (creds.activeInHierarchy == false)
        {
            creds.SetActive(true);
        }
        else
        {
            creds.SetActive(false);
        }
	}
}
