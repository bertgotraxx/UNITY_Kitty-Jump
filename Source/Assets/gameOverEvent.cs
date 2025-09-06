using System;
using UnityEngine;
using UnityEngine.UI;

public class gameOverEvent : MonoBehaviour
{
    public Canvas GameOverScreen;

    private void Start()
    {
        showGameOverScreen(false);
        Time.timeScale = 1f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(collision.gameObject);
            showGameOverScreen(true);
        }
    }

    public void showGameOverScreen(bool value)
    {
        GameOverScreen.enabled = value;

        switch (value)
        {
            case true:
                //saveSystem.SaveHighScoreInfo(Int32.Parse(GameObject.Find("Score").GetComponent<Text>().text));
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
