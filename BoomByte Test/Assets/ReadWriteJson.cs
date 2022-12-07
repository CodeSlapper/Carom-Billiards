using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ReadWriteJson : MonoBehaviour
{

    //save as json
   public void SaveToJson()
   {
        GameOverData playerData = new GameOverData();
        playerData.scoreData = StaticVariables.totalScore;
        playerData.attemptsData = StaticVariables.totalAttempts;
        playerData.timeData = StaticVariables.totalTime;

        string json = JsonUtility.ToJson(playerData, true);
        File.WriteAllText(Application.dataPath+ "/PlayerDataFile",json);
   }

    public void LoadFromJson()
    {
        string json = File.ReadAllText(Application.dataPath + "/PlayerDataFile.json" );
        GameOverData playerData = JsonUtility.FromJson<GameOverData>(json);

        StaticVariables.totalScore = playerData.scoreData;
        StaticVariables.totalAttempts = playerData.attemptsData;
        StaticVariables.totalTime = playerData.timeData;
    }
}
