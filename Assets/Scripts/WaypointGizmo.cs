using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointGizmo : MonoBehaviour {

    public float size = 1f;
    private Transform[] waypoints;
    //int currentWaypoint = 0;

    int choice;
    private void OnDrawGizmos()
    {
        waypoints = gameObject.GetComponentsInChildren<Transform>();

        Vector3 last = waypoints[waypoints.Length - 1].position;
        for (int i = 1; i < waypoints.Length; i++)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(waypoints[i].position, size);
            Gizmos.DrawLine(last, waypoints[i].position);
            last = waypoints[i].position;
        }
    }

    // Use this for initialization
    void Start () {
        //choice = Random.RandomRange(0, waypoints[].count);
        //currentWaypoint = FindClosestWaypoint();
    }
	
	// Update is called once per frame
	void Update () {
        //Vector3 Spawnpoint = waypoints[choice].transform.position;
        //Transform nextWaypoints = waypoints[choice++];
	}
}
