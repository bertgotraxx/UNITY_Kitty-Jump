using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Interactions : MonoBehaviour
{
    // Function that loads the scene that matches the value in argument "sceneName"
    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Function that terminates the game in case it's launched on PC platform
    public void Exit()
    {
        Application.Quit();
    }
}
