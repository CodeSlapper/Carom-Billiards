using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSet : MonoBehaviour
{
    //gettin a reference of time
    public CueStrike cueStrikeScript;

    public GameObject _camRef;
    public GameObject _cueBallRef;
    LineRenderer _lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        _lineRenderer = GetComponent <LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //creating the direction relative to the camera and ball (same application on CueStrike.cs)
        var forward = Camera.main.transform.forward;
        var actualForward = Vector3.ProjectOnPlane(forward, Vector3.up).normalized;
        var startPoint = _cueBallRef.transform.position;
        var endpoint = startPoint + actualForward * ((cueStrikeScript.forceMultiplier/100)+ cueStrikeScript.timer);
        _lineRenderer.SetPosition(0,startPoint);
        _lineRenderer.SetPosition(1, endpoint);
    }
}
