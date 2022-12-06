using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCounce : MonoBehaviour
{
    private Rigidbody rb;

    Vector3 ballVelocity;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        ballVelocity = rb.velocity;
    }
    /*if a ball strikes a still ball since its velocity is 0, it will not move when touched. 
     hence making a condition to make the balls bounce only off of objects with the tag wall */
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            var speed = ballVelocity.magnitude;
            var direction = Vector3.Reflect(ballVelocity.normalized, collision.contacts[0].normal);

            rb.velocity = direction * Mathf.Max(speed, 0f);
        }
    }
}
