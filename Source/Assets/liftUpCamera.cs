using UnityEngine;

public class liftUpCamera : MonoBehaviour
{
    Rigidbody2D camerasRB;
    public Camera gameCamera;

    // Assign game camera's RigidBody to variable "camerasRB"
    void Start()
    {
        camerasRB = gameCamera.GetComponent<Rigidbody2D>();
    }

    // On game scene there's invisible box collider that detects, if there's a player object in it or not
    // and if it collides with player, then it makes the camera to go up
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.transform.tag)
        {
            case "Player":
                camerasRB.linearVelocityY = collision.GetComponent<Rigidbody2D>().linearVelocityY;
                break;
        }
    }

    // If player stays in collider, then camera will go up further
    private void OnTriggerStay2D(Collider2D collision)
    {
        switch (collision.transform.tag)
        {
            case "Player":
                camerasRB.linearVelocityY = collision.GetComponent<Rigidbody2D>().linearVelocityY;
                break;
        }
    }

    // If player leaves the collider, then camera stays on it's current position
    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.transform.tag)
        {
            case "Player":
                camerasRB.linearVelocityY = 0f;
                break;
        }
    }
}
