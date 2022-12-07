using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsScript : MonoBehaviour
{
    Rigidbody rb;
    List<GameObject> collisionHistory = new List<GameObject>();
    //getting a refernce of the boolean isMoving
    public CueDisable moveRef;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        if(!moveRef.isMoving)
        {
            if (collisionHistory.Count > 0)
            {
                if (checkForBalls(collisionHistory))
                {
                    StaticVariables.totalScore++;
                    Debug.Log("You scored!");
                    collisionHistory.Clear();
                }
                else
                {
                    Debug.Log("You missed!, Try again");
                }
            }
        }
    }
    //creating a list of all non-repeating collisions, if it contains both balls the player gets a point (list is cleared when ball is no longer moving)
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "Table")
        {
            if (!collisionHistory.Contains(collision.gameObject))
            {
                collisionHistory.Add(collision.gameObject);
                foreach (GameObject touch in collisionHistory)
                {
                    //Debug.Log("history: " + touch.name);
                }
            }
        }
    }
    //checking wheter the cue ball has colided with both balls while moving
    private bool checkForBalls(List<GameObject> pCollisionHistory)
    {
        bool redCheck = false;
        bool yellowCheck = false;
        foreach (GameObject objects in pCollisionHistory)
        {
            if(objects.name=="RedBall")
            {
                redCheck = true;
            }
            if(objects.name=="YellowBall")
            {
                yellowCheck = true;
            }
        }
        if(redCheck && yellowCheck)
        {
            return true;
        }
        return false;
    }
}
