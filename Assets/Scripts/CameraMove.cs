using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour 
{
	public float verticalMoveArea = 0.95f;
	public float horizontalMoveArea = 0.95f;
	private Vector3 targetPosition;
	private Vector3 targetCameraPosition;
	public float moveSpeed = 1.0f;
	public float moveDistance = 1.0f;
	public float scrollDamp;
	public int maxThreshhold = 25;
	public int minThreshhold = 5;
	void Start()
	{
		targetPosition = transform.position;
		targetCameraPosition = Camera.main.transform.localPosition;
	}
	void Update () 
	{
		if (Input.mousePosition.x > (Screen.width) * horizontalMoveArea)
			targetPosition.x += moveDistance;
		if (Input.mousePosition.x < (Screen.width) * (1-horizontalMoveArea))
			targetPosition.x -= moveDistance;		
		if (Input.mousePosition.y > (Screen.height) * verticalMoveArea)
			targetPosition.z += moveDistance;
		if (Input.mousePosition.y < (Screen.height) * (1-verticalMoveArea))
			targetPosition.z -= moveDistance;
		targetCameraPosition.y += Input.GetAxis("Mouse ScrollWheel")*scrollDamp;
		if (targetCameraPosition.y > maxThreshhold)
			targetCameraPosition.y = maxThreshhold;
		if (targetCameraPosition.y < minThreshhold)
			targetCameraPosition.y = minThreshhold;
		Camera.main.transform.localPosition = Vector3.Lerp(Camera.main.transform.localPosition,targetCameraPosition,Time.deltaTime*moveSpeed);
		Camera.main.transform.LookAt(transform.position);
		transform.position = Vector3.Lerp(transform.position,targetPosition,Time.deltaTime * moveSpeed);
	}
}
