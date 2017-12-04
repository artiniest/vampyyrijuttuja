using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour 
{
	public Transform target;
	public float smoothSpeed = 10f;
	public Vector3 offSet;

	public static float shakeDuration = 0f;
	public float shakeAmount = 0.01f;
	public float decrease = 2;

	void LateUpdate()
	{
		Vector2 desiredPosition = target.position + offSet;
		Vector2 smoothedPosition = Vector2.Lerp(transform.position, desiredPosition, smoothSpeed);
		transform.position = smoothedPosition;

		Transform curPos = transform;
		Vector2 curVecPos = curPos.position;

		if (shakeDuration > 0)
		{
			transform.position = curVecPos + Random.insideUnitCircle * shakeAmount / 10;
			shakeDuration -= Time.deltaTime * decrease;
		}

		transform.position = new Vector3(transform.position.x, transform.position.y, -10);
	}
}
