﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueStrike : MonoBehaviour
{
    int strikeAttempts = 0;
    //need the position of the cue ball and the camera to create the direction the velocity/force will be coming from
    public GameObject camRef;
    Rigidbody rg;
    //making float public to be accessed by Lineset (visually increase line direction with power used)
    public float timer=0;
    void Start()
    {
        rg = GetComponent<Rigidbody>();
    }
    void Update()
    {
        /*while holding down count the seconds, 
         when released add force to the ball equal to the time and a multiplier */
        if (Input.GetKey("v"))
        {
            timer += Time.deltaTime;

        }
        if(Input.GetKeyUp("v"))
        {
            //creating the direction relative to the camera and ball
            var forward = Camera.main.transform.forward;
            var actualForward = Vector3.ProjectOnPlane(forward, Vector3.up).normalized;
            var startPoint = this.transform.position;
            var endpoint = startPoint + actualForward;

            rg.AddForce((endpoint - startPoint) * (timer*100));
            float seconds = Mathf.FloorToInt(timer % 60);
            Debug.Log("key was held for: " + seconds);
            timer = 0f;
            strikeAttempts++;
            Debug.Log("Attempts so far: " + strikeAttempts);
        }
       
    }
}