using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindClosestWaypoint : MonoBehaviour {

    public Transform[] waypts;

    int cWaypoint = 0;

    //float rSpeed = 0.2f;
    float speed = 10.0f;
    float accWaypoint = 1.0f;

    //List<Transform> path = new List<Transform>();
	// Use this for initialization
	void Start () {
        //Setting the closest waypoint 
        cWaypoint = FindWaypoint();
        /*foreach(Transform w in waypts)
        {
            path.Add(w.transform);
        }*/
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 direction = waypts[cWaypoint].transform.position - transform.position;
        //var rotation = Quaternion.LookRotation(direction);
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rSpeed * Time.deltaTime);
        transform.Translate(0, 0, Time.deltaTime * speed);

        if(direction.magnitude < accWaypoint)
        {
            //path.Remove(path[cWaypoint]);
            cWaypoint = FindWaypoint();
        }
	}

    public int FindWaypoint()
    {
        //Making sure that there's no waypoint that had been set up 
        //if (waypts.Length == 0)
        if(waypts.Length == 0)
            return -1;

        int closest = 0;
        //Setting Last Distance
        float lDist = Vector3.Distance(this.transform.position, waypts[0].transform.position);

        for(int i = 1; i < waypts.Length; i++)
        {
            //Setting current distance of the object and the nearest waypoint
            float cDist = Vector3.Distance(this.transform.position, waypts[i].transform.position);
            //updating the closest variable by comparing the last distance from the current
            if(lDist > cDist && i != cWaypoint)
            {
                closest = i;
            }
        }

        return closest;
    }
}
