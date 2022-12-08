using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReplayIndicator : MonoBehaviour
{
    public MoveReplay replayRef;
    public Text replayUI;
    // Start is called before the first frame update
    void Start()
    {
        replayUI.text = "Press R for replay (off)";
    }

    // Update is called once per frame
    void Update()
    {
        if(replayRef.replayOn)
        {
            replayUI.text = "Press R for replay (on)";
        }
        else
        {
            replayUI.text = "Press R for replay (off)";
        }
    }
}
