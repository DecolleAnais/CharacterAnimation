using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

    public Transform brick;
    public int m_width = 3;
    public int m_height = 2;

	// Use this for initialization
	void Start () {
        // get size of brick
        Renderer renderer = brick.GetComponent<Renderer>();
        float width = renderer.bounds.size.x;
        float height = renderer.bounds.size.y;

        // create the wall
		for(int y = 0;y < m_height;y++)
        {
            for(int x = 0;x < m_width;x++)
            {
                // brick from transform field (brick prefab)
                Instantiate(brick, new Vector3(x * width, y * height, 0) + transform.position, Quaternion.identity);

                /*
                //GameObject cube = (GameObject)AssetData ;
                //GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                GameObject cube = GameObject.Find("Cube");
                // scale
                //cube.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

                // position               

                Vector3 pos = transform.position;

                //cube.transform.position = new Vector3(10.0f, 10.0f, 10.0f);
                cube.transform.position = new Vector3(0.0f, (float)i * 1.5f, (float)j);
                cube.transform.position += pos;

                // rigibody
                Rigidbody rigidbody = cube.AddComponent<Rigidbody>();
                rigidbody.mass = 1;
                */
                
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
