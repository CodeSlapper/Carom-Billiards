using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueStrike : MonoBehaviour
{
    /*problem with replay: it would only clear the cueball replay history
     and missmatch the replay as one would do the last move while others 
     would do every single one*/
    private GameObject redRef;
    private GameObject yellowRef;

    private MoveReplay redReplay;
    private MoveReplay yellowReplay;

    public MoveReplay replayRef;
    //need the position of the cue ball and the camera to create the direction the velocity/force will be coming from
    public GameObject camRef;
    Rigidbody rg;
    //making float public to be accessed by Lineset (visually increase line direction with power used)
    public float timer=0;
    public int forceMultiplier = 300;
    void Start()
    {
        rg = GetComponent<Rigidbody>();

        redRef = GameObject.Find("RedBall");
        yellowRef = GameObject.Find("YellowBall");

        yellowReplay = yellowRef.GetComponent<MoveReplay>();
        redReplay = redRef.GetComponent<MoveReplay>();
    }
    void Update()
    {
        /*while holding down count the seconds, 
         when released add force to the ball equal to the time and a multiplier */
        if (Input.GetKey(KeyCode.Space))
        {
            timer += Time.deltaTime;

        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            Strike(rg);
        }
       
    }
    private void Strike(Rigidbody pRB)
    {
        //creating the direction relative to the camera and ball
        var forward = Camera.main.transform.forward;
        var actualForward = Vector3.ProjectOnPlane(forward, Vector3.up).normalized;
        var startPoint = this.transform.position;
        var endpoint = startPoint + actualForward;

        //timer by itself is too low of a value, a multiplier is used to increased the force applied
        if (timer <= 10f)
        {
            pRB.AddForce((endpoint - startPoint) * (timer * forceMultiplier));
        }
        else
        {
            pRB.AddForce((endpoint - startPoint) * (10f * forceMultiplier));
        }
        float seconds = Mathf.FloorToInt(timer % 60);

        timer = 0f;
        if (!replayRef.replayOn)
        {
            StaticVariables.totalAttempts++;
            replayRef.MoveReset();
            redReplay.MoveReset();
            yellowReplay.MoveReset();
        }
    }
}
