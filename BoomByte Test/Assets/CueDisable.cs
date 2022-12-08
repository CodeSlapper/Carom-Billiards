using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueDisable : MonoBehaviour
{
    Rigidbody rb;
    public bool isMoving;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        isMoving = false;
    }

    void Update()
    {
        if(rb.velocity.magnitude>0.4f)
        {
            this.GetComponent<CueStrike>().enabled = false;
            isMoving = true;
           //Debug.Log("Ball is moving you can't strike n/ " + rb.velocity.magnitude);
        }
        else
        {
            this.GetComponent<CueStrike>().enabled = true;
            isMoving = false;
            //Debug.Log("Strike enabled: " + rb.velocity.magnitude);
        }

    }
}
