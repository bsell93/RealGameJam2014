using UnityEngine;
using System.Collections;

public class AddToUnitManagerOnClick : MonoBehaviour 
{
	private UnitManager uManager;
	
	void Start()
	{
		uManager = GameObject.FindGameObjectWithTag("God").GetComponent("UnitManager") as UnitManager;
	}

	void Clicked(Vector3 point)
	{
		if (!uManager.unitManager.Contains (gameObject.transform.root.gameObject)) 
		{
			uManager.unitManager.Add (gameObject.transform.root.gameObject);
		}
	}
}
