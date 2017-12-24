using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour {

    public
    float m_speed;
    float m_speed_max;
    float m_rotation_speed;
    Vector3 m_input;


    // Use this for initialization
    void Start () {
        m_speed = 0.1f;
        m_speed_max = 5.0f;
        m_rotation_speed = 8.0f;
        m_input = new Vector3(0, 0, 1); //Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    // Update is called once per frame
    void Update () {
        //transform.position += m_input * m_speed * Time.deltaTime;

        // mouse rotation
        Vector2 mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        transform.Rotate(Vector3.up, mouseInput.x * m_rotation_speed);

        // speed translations
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (m_speed < m_speed_max) m_speed *= 1.1f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            m_speed *= 0.9f;
        }
        // rotations
        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.up, m_rotation_speed);
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(Vector3.up, -m_rotation_speed);

        // move
        gameObject.GetComponent<CharacterController>().
            Move(transform.TransformDirection(m_input * m_speed * Time.deltaTime));
        
    }
}
