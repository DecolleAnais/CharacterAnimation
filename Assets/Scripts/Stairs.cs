using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour {

    public Transform brick;
    public Vector3 m_scale;
    public float m_stepHeightY;
    public float m_stepLenghtZ;
    public float m_nbSteps;

    // Use this for initialization
    void Start()
    {
        Transform step = Instantiate(brick) as Transform;
        
        // deactivate gravity and movement for stairs
        Rigidbody rb = step.GetComponent<Rigidbody>();
        //rb.detectCollisions = false;
        rb.isKinematic = true;
        rb.useGravity = false;

        // scale the brick
        step.localScale = new Vector3(m_scale.x, m_scale.y, m_scale.z);

        step.position = transform.position;

        // create the stairs
        for (int i = 0; i < m_nbSteps; i++)
        {
            // brick from transform field (brick prefab)
            step = Instantiate(step, step.position/* + transform.position*/, Quaternion.identity);
            
            // translation for the next step
            float x = step.position.x;
            float y = step.position.y + m_stepHeightY;
            float z = step.position.z + m_stepLenghtZ;
            step.position = new Vector3(x, y, z);
            
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
