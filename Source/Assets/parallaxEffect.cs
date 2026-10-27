using UnityEngine;

public class parallaxEffect : MonoBehaviour
{
    float length, startPosition;
    public Camera gameCamera;

    // On game start - it sets the start position which is background's current height
    // and gets length of the background image
    void Start()
    {
        startPosition = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // Background consists from two images, first it starts with the first (Bottom) image
    // and as the game camera moves, first backgrounds image moves aswell and when the first
    // background reaches the top and finishing transition between first and second (Top) images
    // the first image moves on the top of second image which makes a smooth parallax effect
    void Update()
    {
        float temp = gameCamera.transform.position.y * (1 - 0.3f);
        float distance = gameCamera.transform.position.y * 0.3f;

        transform.position = new Vector2(transform.position.x, startPosition + distance);

        if (temp > startPosition + length)
        {
            startPosition += length;
        }
    }
}
