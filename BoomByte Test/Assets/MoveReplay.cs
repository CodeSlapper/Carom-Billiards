using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveReplay : MonoBehaviour
{
    GameObject cueBallref;
    private int currentReplayIndex;
    public bool replayOn;
    private Rigidbody rb;
    private List<MoveReplayRecord> moveRecorded = new List<MoveReplayRecord>();

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cueBallref = GameObject.Find("CueBall");
    }

    // making the RB kinematic to disable collisions in replay
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            if (rb.velocity.magnitude < 0.4f)
            {
                replayOn = !replayOn;

                if (replayOn)
                {
                    SetTransform(0);
                    rb.isKinematic = true;
                }
                else
                {
                    if (moveRecorded.Count > 0)
                    {
                        SetTransform(moveRecorded.Count - 1);
                        
                    }
                    rb.isKinematic = false;
                }
            }
        }
    }
    //if replay is off save frame while the cue strike is disabled which means the balls is moving
    void FixedUpdate()
    {
        if (replayOn == false)
        {
            
            if (!cueBallref.GetComponent<CueStrike>().isActiveAndEnabled)
            {
                moveRecorded.Add(new MoveReplayRecord { position = transform.position, rotation = transform.rotation });
            }
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
    public void MoveReset()
    {
        moveRecorded.Clear();
    }
}
