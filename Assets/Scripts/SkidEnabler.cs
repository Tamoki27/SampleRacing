using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkidEnabler : MonoBehaviour {

    public WheelCollider wheelCollider;
    public GameObject skidTrailRenderer;
    public float skidLife = 1.0f;
    private TrailRenderer skidmark;

	// Use this for initialization
	void Start () {
        skidmark = skidTrailRenderer.GetComponent<TrailRenderer>();
        skidmark.time = skidLife;
	}
	
	// Update is called once per frame
	void Update () {
		if(wheelCollider.forwardFriction.stiffness < 1 && wheelCollider.isGrounded)
        {
            if(skidmark.time == 0)
            {
                skidmark.time = skidLife;
                skidTrailRenderer.transform.parent = wheelCollider.transform;
                skidTrailRenderer.transform.localPosition = wheelCollider.center + ((wheelCollider.radius - 0.1f) * -wheelCollider.transform.up);
            }

            if(skidTrailRenderer.transform.parent == null)
            {
                skidmark.time = 0;
            }
        }
        else
        {
            skidTrailRenderer.transform.parent = null;
        }
	}
}
