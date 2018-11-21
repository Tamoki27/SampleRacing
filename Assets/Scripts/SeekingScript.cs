using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekingScript : MonoBehaviour {

    private Transform target;
    private int distance = 1;
    private float rotationSpeed = 1.0f;
    RivalCarController rc;
    //int moveSpeed = 5;

    // Use this for initialization
    void Start()
    {
        rc = GetComponent<RivalCarController>();
    }

   
    void FixedUpdate()
    {
        target = GameObject.FindGameObjectWithTag("CarAI").transform;
        SeekCarAi();
    }

    void SeekCarAi()
    {
        Vector3 direction = target.transform.position - transform.position;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
        //transform.rotation = Quaternion.LookRotation(GetComponent<Rigidbody>().velocity);

        if (direction.magnitude > distance)
        {

            //Vector3 moveCar = direction.normalized * moveSpeed * Time.deltaTime;
            //transform.position += moveCar;
            float speed = rc.GetCurrentSpeed() * Time.deltaTime;
            transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position, speed);

            

        }
    }
     
}
