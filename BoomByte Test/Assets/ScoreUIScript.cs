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
        Debug.Log("attemps are: " + strikeRef.strikeAttempts.ToString());
    }
}
