using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueDisable : MonoBehaviour
{
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        while(rb.velocity.magnitude!=0)
        {
            this.GetComponent<CueStrike>().enabled = false;
            Debug.Log("Ball is moving you can't strike");
        }
        this.GetComponent<CueStrike>().enabled = true;
        Debug.Log("Strike enabled");
    }
}
