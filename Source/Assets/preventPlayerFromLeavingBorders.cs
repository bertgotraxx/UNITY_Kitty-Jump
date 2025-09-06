using Unity.Mathematics;
using UnityEngine;

public class preventPlayerFromLeavingBorders : MonoBehaviour
{
    public Camera gameCamera;
    private Vector2 screenBounds;

    void Update()
    {
        screenBounds = gameCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, gameCamera.transform.position.z));
        Vector2 viewPoint = transform.position;
        viewPoint.x = math.clamp(viewPoint.x, screenBounds.x * -1, screenBounds.x);
        transform.position = viewPoint;
    }
}
