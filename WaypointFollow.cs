using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollow : MonoBehaviour {

    public GameObject[] waypoints;
    int currentWP = 0;

    float speed = 0.6f;
    float accuracy = 1.0f;
    float rotSpeed = 0.2f;

	// Use this for initialization
	void Start () {
        waypoints = GameObject.FindGameObjectsWithTag("waypoint");
	}
	
	// Update is called once per frame
	void Update () {
        if (waypoints.Length == 0) return;

        Vector3 lookAtGoal = new Vector3(waypoints[currentWP].transform.position.x,
            this.transform.position.y,
            waypoints[currentWP].transform.position.z);
        Vector3 direction = lookAtGoal - this.transform.position;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
            Quaternion.LookRotation(direction),
            Time.deltaTime * rotSpeed);
        if(direction.magnitude < accuracy)
        {
            currentWP++;
            if(currentWP >= waypoints.Length)
            {
                currentWP = 0;
            }
        }
        this.transform.Translate(0, 0, speed * Time.deltaTime);
	}
}
