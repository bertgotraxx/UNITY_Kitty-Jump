using UnityEngine;

public class parallaxEffect : MonoBehaviour
{
    float length, startPosition;
    public Camera gameCamera;

    void Start()
    {
        startPosition = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.y;
    }

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
