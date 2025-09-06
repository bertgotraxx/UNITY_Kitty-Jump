using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class loadData : MonoBehaviour
{
    void Start()
    {
        //string filePath = Application.persistentDataPath + saveSystem.FILENAME_SAVEDATA;
        //string fileContent = File.ReadAllText(filePath);
        //SaveData saveData = JsonUtility.FromJson<SaveData>(fileContent);
        //GameObject.Find("HighScore").GetComponent<Text>().text = saveData.HighScore.ToString();
        SaveInfo Data = _SaveSystem.LoadGameData();
        GameObject.Find("HighScore").GetComponent<Text>().text = Data.scoreData.score.ToString();
    }
}
