using UnityEngine;
using Unity.Mathematics;
using Unity.VisualScripting;

public class movingPlatformScript : MonoBehaviour
{
    public Camera gameCamera;
    private Rigidbody2D RB2;
    private Vector2 screenBounds;

    private void Start()
    {
        RB2 = gameObject.GetComponent<Rigidbody2D>();
        RB2.linearVelocityX = -2;
    }

    void Update()
    {
        screenBounds = gameCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, gameCamera.transform.position.z));

        if (transform.position.x <= screenBounds.x * -1)
        {
            RB2.linearVelocityX = 2;
        }
        else if (transform.position.x >= screenBounds.x)
        {
            RB2.linearVelocityX = -2;
        }
    }
}
