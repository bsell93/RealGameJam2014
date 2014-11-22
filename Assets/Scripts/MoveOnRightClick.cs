using UnityEngine;
using System.Collections;

public class MoveOnRightClick : MonoBehaviour {

	private UnitManager uManager;
	
	void Start()
	{
		uManager = GameObject.FindGameObjectWithTag("God").GetComponent("UnitManager") as UnitManager;
	}
	void RighClicked(Vector3 place)
	{
		foreach (GameObject unit in uManager.unitManager)
			unit.GetComponent<Pathfinder>().GoTo(place);
	}
}
