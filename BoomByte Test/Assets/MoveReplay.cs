using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveReplay : MonoBehaviour
{
    private int currentReplayIndex;
    public bool replayOn;
    private Rigidbody rb;
    private List<MoveReplayRecord> moveRecorded = new List<MoveReplayRecord> ();
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // making the RB kinematic to disable collisions in replay
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            replayOn = !replayOn;

            if(replayOn)
            {
                SetTransform(0);
                rb.isKinematic = true;
            }
            else
            {
                SetTransform(moveRecorded.Count - 1);
                rb.isKinematic = false;
            }
        }
    }
    //recording every frame even in replay, if statement prevents that
    void FixedUpdate()
    {
        if (replayOn == false)
        {
            moveRecorded.Add(new MoveReplayRecord { position = transform.position, rotation = transform.rotation });
        }
        else
        {
            int nextIndex = currentReplayIndex + 1;

            if (nextIndex < moveRecorded.Count)
            {
                SetTransform(nextIndex);
            }

        }
    }
    //getting index of frames
    private void SetTransform(int index)
    {
        currentReplayIndex = index;
        MoveReplayRecord MoveReplayRecord = moveRecorded[index];

        //set position of object to that of stored record
        transform.position = MoveReplayRecord.position;
        transform.rotation = MoveReplayRecord.rotation;
    }
}
