using UnityEngine;

public class SystemParameters : MonoBehaviour
{
    [SerializeField] GameObject EXIT_BUTTON;
    private void Start()
    {
        EXIT_BUTTON = gameObject.transform.GetChild(2).gameObject;

        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            EXIT_BUTTON.SetActive(false);
        }
    }
}
