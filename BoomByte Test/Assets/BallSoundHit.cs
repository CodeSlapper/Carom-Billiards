using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSoundHit : MonoBehaviour
{
     AudioSource hitEffect;
    Rigidbody gb;
    void Start()
    {
        hitEffect = GetComponent<AudioSource>();
        gb = GetComponent<Rigidbody>();
    }
    //need to make sure that if two balls strike each other, only one of the sources will play
    void OnCollisionEnter(Collision collision)
    {
        //volume is between 0 and 1, need to divide relativeSound for a more realistic number
        float relativeSound = (gb.velocity.magnitude) / 20;
        if (collision.gameObject.tag != "Table")
        {
            hitEffect.volume = relativeSound;
            hitEffect.Play();
        }
    }
}
