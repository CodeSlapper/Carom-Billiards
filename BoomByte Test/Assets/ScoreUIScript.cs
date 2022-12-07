using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUIScript : MonoBehaviour
{
    public PointsScript pointsRef;
    public CueStrike strikeRef;

    public Text scoreText;
    public Text attemptsText;
    public Text timerUI;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + pointsRef.score.ToString();
        //Bug: renamed Attempts: to Moves: as it would not show the integer
        attemptsText.text = "Moves: " +strikeRef.strikeAttempts.ToString();
        timer += Time.deltaTime;
        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer % 60F);
        int milliseconds = Mathf.FloorToInt((timer * 100F) % 100F);
        timerUI.text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("00");
    }
}
