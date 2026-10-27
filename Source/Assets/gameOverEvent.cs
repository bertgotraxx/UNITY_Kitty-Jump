using System;
using UnityEngine;
using UnityEngine.UI;

public class gameOverEvent : MonoBehaviour
{
    public Canvas GameOverScreen;

    // On game restart - hide game over screen and set time scale back to default
    private void Start()
    {
        showGameOverScreen(false);
        Time.timeScale = 1f;
    }

    // Function that shows or hides game over screen. In case the value is true
    // then save player data
    public void showGameOverScreen(bool value)
    {
        GameOverScreen.enabled = value;

        switch (value)
        {
            case true:
                if (Int32.Parse(GameObject.Find("Score").GetComponent<Text>().text) 
                    > Int32.Parse(GameObject.Find("HighScore").GetComponent<Text>().text))
                {
                    _SaveSystem.SaveGameData();
                }
                Time.timeScale = 0f;
                break;
        }
    }
}
