using Unity.Mathematics;
using UnityEngine;

public class preventPlayerFromLeavingBorders : MonoBehaviour
{
    public Camera gameCamera;
    private Vector2 screenBounds;

    // This code piece prevents player from leaving the screen borders
    void Update()
    {
        // Variable that contains device's screen dimensions
        screenBounds = gameCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, gameCamera.transform.position.z));
        Vector2 viewPoint = transform.position;
        // Clamps X coordinates in order to prevent player from leaving screen borders
        viewPoint.x = math.clamp(viewPoint.x, screenBounds.x * -1, screenBounds.x);
        // Applies the value from "viewPoint"
        transform.position = viewPoint;
    }
}
