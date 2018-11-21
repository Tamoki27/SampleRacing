using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerScript : MonoBehaviour {

    private GameObject[] spawn;
    public GameObject[] carAIobj;
    public ObjectPoolManager pool;
    public GameObject tmp;

    public float timer = 1f;
    public float maxTime = 5f;

    // Use this for initialization
    void Start () {
        //Initializing the Object pool instance
        pool = ObjectPoolManager.Instance;
	}  
      
    // Update is called once per frame
    void FixedUpdate()
    {
        carAIobj = GameObject.FindGameObjectsWithTag("CarAI");
        //Sets value for variable "timer" equal to the delta time
        timer += Time.deltaTime;
        //if condition is met, executes Spawner function and sets back the timer to 1
        if(timer > maxTime)
        {
            timer = 1f;
            Spawner();
        }
    
     }

    private void Spawner()
    {
        //Sets the spawn position corresponding to spawnobject's x,y,z position
        Vector3 position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        tmp = pool.GetObjectForType("CarAI", true);
        tmp.transform.position = position;
    }


}
