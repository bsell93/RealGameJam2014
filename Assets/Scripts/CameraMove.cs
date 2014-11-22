using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour 
{
	public float sideMoveArea = 0.95f;
	void Update () 
	{
		if (Input.mousePosition.x > Screen.width * sideMoveArea)
			Debug.Log("Hey there");
	}
}
