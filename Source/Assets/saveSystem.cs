using System;
using System.IO;
using UnityEngine;

public class saveSystem : MonoBehaviour
{
    public const string FILENAME_SAVEDATA = "/savedata.json";

    public static void SaveHighScoreInfo(int highScore)
    {
        string filePathSaveData = Application.persistentDataPath + FILENAME_SAVEDATA;
        SaveData saveData = new SaveData(highScore);
        string txt = JsonUtility.ToJson(saveData);
        //File.WriteAllText(filePathSaveData, txt);
        if (JsonUtility.FromJson<SaveData>(File.ReadAllText(filePathSaveData)).HighScore > highScore)
        {
            return;
        }
        else
        {
            File.WriteAllText(filePathSaveData, txt);
        }
    }
}

[Serializable]

public class SaveData
{
    [SerializeField] public int HighScore;

    public SaveData(int HighScore)
    {
        this.HighScore = HighScore;
    }
}
