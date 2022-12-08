using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUIScript : MonoBehaviour
{
    public Text scoreText;
    public Text attemptsText;
    public Text timerUI;
    public MoveReplay timeMoveRef;

    void Start()
    {
    }

    void Update()
    {
        scoreText.text = "Score: " + StaticVariables.totalScore.ToString();
        //Bug: renamed Attempts: to Moves: as it would not show the integer
        attemptsText.text = "Moves: " +StaticVariables.totalAttempts.ToString();

        if(!timeMoveRef.replayOn)
        {
            StaticVariables.totalTime += Time.deltaTime;
            int minutes = Mathf.FloorToInt(StaticVariables.totalTime / 60F);
            int seconds = Mathf.FloorToInt(StaticVariables.totalTime % 60F);
            int milliseconds = Mathf.FloorToInt((StaticVariables.totalTime * 100F) % 100F);
            timerUI.text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("00");
        }
    }
}
