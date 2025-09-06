using UnityEngine;

public class liftUpCamera : MonoBehaviour
{
    Rigidbody2D camerasRB;
    public Camera gameCamera;

    void Start()
    {
        camerasRB = gameCamera.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.transform.tag == "Player")
        //{
        //    camerasRB.linearVelocityY = collision.transform.GetComponent<Rigidbody2D>().linearVelocityY;
        //}
        switch (collision.transform.tag)
        {
            case "Player":
                camerasRB.linearVelocityY = collision.GetComponent<Rigidbody2D>().linearVelocityY;
                break;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        switch (collision.transform.tag)
        {
            case "Player":
                camerasRB.linearVelocityY = collision.GetComponent<Rigidbody2D>().linearVelocityY;
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //if (collision.transform.tag == "Player")
        //{
        //    camerasRB.linearVelocityY = 0f;
        //}
        switch (collision.transform.tag)
        {
            case "Player":
                camerasRB.linearVelocityY = 0f;
                break;
        }
    }

    //void Update()
    //{

    //}
}
