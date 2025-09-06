using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Interactions : MonoBehaviour
{
    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
