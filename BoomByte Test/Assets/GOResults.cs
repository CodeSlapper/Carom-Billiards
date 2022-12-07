using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GOResults : MonoBehaviour
{
    public ReadWriteJson save;
    Text resultsUI;
    void Start()
    {
        resultsUI = GetComponent<Text>();
        int minutes = Mathf.FloorToInt(StaticVariables.totalTime / 60F);
        int seconds = Mathf.FloorToInt(StaticVariables.totalTime % 60F);
        int milliseconds = Mathf.FloorToInt((StaticVariables.totalTime * 100F) % 100F);
        resultsUI.text = "Score: " + StaticVariables.totalScore.ToString() +
            " Moves: " + StaticVariables.totalAttempts.ToString() + " Time: " + minutes.ToString("00") + ":" +
            seconds.ToString("00") + ":" + milliseconds.ToString("00");

        save.SaveToJson();
    }

 
}
