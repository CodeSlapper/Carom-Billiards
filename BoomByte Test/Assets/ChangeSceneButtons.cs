using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneButtons : MonoBehaviour
{
    // 0 is menu, 1 is the game, 2 is the end screen
   public void LoadScene()
   {
        if(this.gameObject.tag == "ToGameBtn")
        {
            ResetStats();
            SceneManager.LoadScene(1);
        }
        if(this.gameObject.tag == "ToMM")
        {
            SceneManager.LoadScene(0);
        }
   }
    void ResetStats()
    {
        StaticVariables.totalScore = 0;
        StaticVariables.totalAttempts = 0;
        StaticVariables.totalTime = 0;
    }
}
