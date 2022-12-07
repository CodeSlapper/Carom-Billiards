using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsScript : MonoBehaviour
{
    Rigidbody rb;
    List<GameObject> collisionHistory = new List<GameObject>();
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "Table")
        {
            if (!collisionHistory.Contains(collision.gameObject))
            {
                collisionHistory.Add(collision.gameObject);
                foreach (GameObject touch in collisionHistory)
                {
                    Debug.Log("history: " + touch.name);
                }
            }
        }
    }
}
