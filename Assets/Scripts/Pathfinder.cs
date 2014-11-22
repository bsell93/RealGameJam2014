using UnityEngine;
using System.Collections;
using Pathfinding;

public class Pathfinder : MonoBehaviour 
{
	public float speed = 100.0f;
	public bool endOfPathReached = true;

	private Seeker seeker;
	public Path path; 

	//The max distance from the AI to a waypoint for it to continue to the next waypoint
	public float nextWaypointDistance = 1;
	//The waypoint we are currently moving towards
	private int currentWaypoint = 0;


	void Start () 
	{
		//this.animation.wrapMode = WrapMode.Loop; //animation
		path = null;
	}

	public void GoTo(Vector3 targetPosition)
	{
		seeker = GetComponent<Seeker>();
		Debug.Log("OOOOOOOOO");
		seeker.StartPath (transform.position,targetPosition, OnPathCalculated);
	}

	public void OnPathCalculated (Path p) 
	{
		//Debug.Log ("Yey, we got a path back. Did it have an error? "+p.error);
		if (!p.error) 
		{
			path = p;
			//Reset the waypoint counter
			currentWaypoint = 0;
			endOfPathReached = false;
			//gameObject.animation.Stop("idle");  //animation
			//gameObject.animation.Play("walk");  //animation
		}
	}
	
	public void FixedUpdate () 
	{
		
		if (path == null) 
			return;
		
		if (currentWaypoint >= path.vectorPath.Count) 
			if (endOfPathReached == false)
				weGotThere ();

		if(path != null)
		{
			//Direction to the next waypoint
			Vector3 direction = (path.vectorPath[currentWaypoint]-transform.position).normalized;
			transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.LookRotation(direction), Time.deltaTime*5);

			direction *= speed * Time.fixedDeltaTime;
			rigidbody.velocity = direction;
		
			
			/*Vector3 eulerAngles = transform.rotation.eulerAngles;
			eulerAngles.x = 0;
			eulerAngles.z = 0;
			
			transform.rotation = Quaternion.Euler(eulerAngles);*/

			//Check if we are close enough to the next waypoint
			//If we are, proceed to follow the next waypoint
			if (Vector3.Distance (transform.position,path.vectorPath[currentWaypoint]) < nextWaypointDistance) 
			{
				currentWaypoint++;
				return;
			}
		}
	}

	public void weGotThere ()
	{
		Debug.Log ("End Of Path Reached");
		path = null;
		endOfPathReached = true;
	}
}
