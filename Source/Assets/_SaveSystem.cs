using System;
using System.IO;
using UnityEngine;

public class _SaveSystem : MonoBehaviour
{
    public const string SAVE_FILE_NAME = "/PLAYERDATA.json";
    public static void SaveGameData()
    {
        string saveFilePath = Application.persistentDataPath + SAVE_FILE_NAME;
        ScoreData scoreData = new ScoreData(GameObject.Find("ScoreTable"));
        SaveInfo saveData = new SaveInfo(scoreData);
        string txt = JsonUtility.ToJson(saveData);
        File.WriteAllText(saveFilePath, txt);
    }

    public static SaveInfo LoadGameData()
    {
        try {
            string saveFilePath = Application.persistentDataPath + SAVE_FILE_NAME;
            string fileContent = File.ReadAllText(saveFilePath);
            SaveInfo saveData = JsonUtility.FromJson<SaveInfo>(fileContent);
            return saveData;
        } 
        catch
        {
            return null;
        }
    }
}

[Serializable]
public class SaveInfo
{
    [SerializeField] public ScoreData scoreData;

    public SaveInfo(ScoreData scoreData)
    {
        this.scoreData = scoreData;
    }
}

[Serializable]
public class ScoreData
{
    [SerializeField] public int score;

    public ScoreData(GameObject scoreTable)
    {
        score = Int32.Parse(scoreTable.GetComponent<highScoreScript>().currentScore.text);
    }
}
