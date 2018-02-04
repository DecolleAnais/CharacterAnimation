using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControllerScript : MonoBehaviour {

    public Animator m_animator;

	// Use this for initialization
	void Start () {
        m_animator = GetComponent<Animator>();
        //Debug.Log("AnimationController: start => Animator");
    }
	
	// Update is called once per frame
	void Update () {
        // jump
        if(Input.GetKeyDown("space"))
        {
            m_animator.SetBool("jump", true);
        }
        if (Input.GetKeyUp("space"))
        {
            m_animator.SetBool("jump", false);
        }

        // crouch
        if(Input.GetKeyDown("left alt"))
        {
            m_animator.SetBool("crouch", true);
        }
        if (Input.GetKeyUp("left alt"))
        {
            m_animator.SetBool("crouch", false);
        }

        // walk - run speed
        m_animator.SetFloat("vSpeed", Input.GetAxis("Vertical")*0.5f + 0.5f*Input.GetAxis("SwitchRunWalk"));
        // turn speed
        m_animator.SetFloat("hSpeed", Input.GetAxis("Horizontal"));


        //Debug.Log("vSpeed = " + Input.GetAxis("Vertical"));
        //Debug.Log("hSpeed = " + Input.GetAxis("Horizontal"));
    }
    

}
