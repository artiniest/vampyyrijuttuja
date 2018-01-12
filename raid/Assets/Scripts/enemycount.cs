using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemycount : MonoBehaviour 
{
	public Sprite[] sprites;
	public SpriteRenderer[] counts;

    public static int enemyNumber;

    void Awake ()
    {
        GameObject [] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyNumber = enemies.Length;
    }

	void Update ()
	{
        switch (enemyNumber)
        {
            case 0:
                counts [0].enabled = false;
                break;
            case 1:
                counts [0].sprite = sprites [0];
                break;
            case 2:
                counts [0].sprite = sprites [1];
                break;
            case 3:
                counts [0].sprite = sprites [2];
                break;
            case 4:
                counts [0].sprite = sprites [3];
                break;
            case 5:
                counts[1].enabled = false;
                counts [0].sprite = sprites [4];
                break;
            case 6:
                counts[1].sprite = sprites[0];
                break;
            case 7:
                counts[1].sprite = sprites[1];
                break;
            case 8:
                counts[1].sprite = sprites[2];
                break;
            case 9:
                counts [1].sprite = sprites [3];
                break;
            case 10:
                counts[2].enabled = false;
                counts [1].sprite = sprites [4];
                break;
            case 11:
                counts [2].sprite = sprites [0];
                break;
            case 12:
                counts [2].sprite = sprites [1];
                break;
            case 13:
                counts [2].sprite = sprites [2];
                break;
            case 14:
                counts [2].sprite = sprites [3];
                break;
            case 15:
                counts [3].enabled = false;
                counts [2].sprite = sprites [4];
                break;
            case 16:
                counts [3].sprite = sprites [0];
                break;
            case 17:
                counts [3].sprite = sprites [1];
                break;
            case 18:
                counts [3].sprite = sprites [2];
                break;
            case 19:
                counts [3].sprite = sprites [3];
                break;
            case 20:
                counts [4].enabled = false;
                counts [3].sprite = sprites [4];
                break;
            case 21:
                counts[4].sprite = sprites[0];
                break;
            case 22:
                counts[4].sprite = sprites[1];
                break;
            case 23:
                counts[4].sprite = sprites[2];
                break;
        }
    }

	public static void OneLess ()
	{
        enemyNumber--;
	}
}
