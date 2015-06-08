using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	private Transform playerPos;
	private bool inSight = false;
	private float sightDistance = 8f;
	private float tagDistance = 2.2f;
	private NavMeshAgent nav;								// Reference to the nav mesh agent.
	private float chaseSpeed = 4.5f;					
	private float patrolSpeed = 3f;
	public Transform[] patrolWayPoints;						// An array of transforms for the patrol route.
	private int wayPointIndex;								// A counter for the way point array.
	public Transform destination;

	// Use this for initialization
	void Start () {
		nav = GetComponent<NavMeshAgent>();
	
	}
	
	// Update is called once per frame
	void Update () {
		inSight = (Vector3.Distance(GameObject.FindGameObjectWithTag ("Player").transform.position, transform.position) < sightDistance);
		if (inSight) {
			Chasing ();
		}
		else {
			Patrolling();
		}

		if (inSight && Vector3.Distance (GameObject.FindGameObjectWithTag ("Player").transform.position, transform.position) < tagDistance) {
			Application.LoadLevel (0);
		}
	}

	void OnTriggerEnter(Collider entry){
		if (entry.tag == "Player") {
			playerPos = entry.transform;
		}
	}

	void Chasing ()
	{
		// Create a vector from the enemy to the last sighting of the player.
		Vector3 sightingDeltaPos = playerPos.position - transform.position;
		
		// If the the last personal sighting of the player is not close...
		if(sightingDeltaPos.sqrMagnitude > 4f)
			// ... set the destination for the NavMeshAgent to the last personal sighting of the player.
			nav.destination = playerPos.position;
		
		// Set the appropriate speed for the NavMeshAgent.
		nav.speed = chaseSpeed;
		destination = playerPos;

	}
	
	
	void Patrolling ()
	{
		// Set an appropriate speed for the NavMeshAgent.
		nav.speed = patrolSpeed;
		
		// If near the next waypoint or there is no destination...
		if(nav.remainingDistance < nav.stoppingDistance)
		{
			// ... increment the wayPointIndex.
			if(wayPointIndex == patrolWayPoints.Length - 1)
				wayPointIndex = 0;
			else
				wayPointIndex++;

		}
		
		// Set the destination to the patrolWayPoint.
		nav.destination = patrolWayPoints[wayPointIndex].position;
		destination = patrolWayPoints [wayPointIndex];
	}
}
