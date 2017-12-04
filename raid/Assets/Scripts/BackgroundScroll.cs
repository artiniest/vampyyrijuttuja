using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour 
{
	public float backGroundSize;

	private Transform cameraTr;
	private Transform[] layers;
	public float viewZone = 1;
	private int leftIndex;
	private int rightIndex;

	public float paralaxSpeed;
	private float lastCameraX;

	private void Start ()
	{
		cameraTr = Camera.main.transform;
		lastCameraX = cameraTr.transform.position.x;
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
		float deltaX = cameraTr.position.x - lastCameraX;
		transform.position += Vector3.right * (deltaX * paralaxSpeed);
		lastCameraX = cameraTr.position.x;

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
		layers[rightIndex].position = Vector2.right * (layers[leftIndex].position.x - backGroundSize);
		leftIndex = rightIndex;
		rightIndex --;
		if (rightIndex < 0)
			rightIndex = layers.Length-1;
	}

	private void ScrollRight ()
	{
		layers[leftIndex].position = Vector2.right * (layers[rightIndex].position.x + backGroundSize);
		rightIndex = leftIndex;
		leftIndex ++;
		if (leftIndex == layers.Length)
			leftIndex = 0;
	}
}
