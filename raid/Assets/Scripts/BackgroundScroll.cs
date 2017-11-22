using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour 
{
	public float backGroundSize;

	private Transform cameraTr;
	private Transform[] layers;
	private float viewZone = 1;
	private int leftIndex;
	private int rightIndex;

	private void Start ()
	{
		cameraTr = Camera.main.transform;
		layers = new Transform[transform.childCount];
		for (int i = 0; i < transform.childCount; i++)
		{
			layers[i] = transform.GetChild(i);
		}

		leftIndex = 0;
		rightIndex = layers.Length-1;
	}

	private void Update()
	{
		if (cameraTr.position.x > (layers[rightIndex].transform.position.x - viewZone))
		{
			ScrollRight();
		}

		if (cameraTr.position.x < (layers[leftIndex].transform.position.x + viewZone))
		{
			ScrollLeft();
		}
	}

	private void ScrollLeft()
	{
		int lastRight = rightIndex;
		layers[rightIndex].position = new Vector2(1, 0)* (layers[leftIndex].position.x - backGroundSize);
		leftIndex = rightIndex;
		rightIndex --;
		if (rightIndex < 0)
			rightIndex = layers.Length-1;
	}

	private void ScrollRight ()
	{
		int lastLeft = leftIndex;
		layers[leftIndex].position = new Vector2(1, 0) * (layers[rightIndex].position.x + backGroundSize);
		rightIndex = leftIndex;
		leftIndex ++;
		if (leftIndex == layers.Length)
			leftIndex = 0;
	}
}
