using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerControls : MonoBehaviour
{

    public Rigidbody2D RB;
    public int SPEED;
    public int JUMP_POWER;
    public InputAction InputAction;
    RaycastHit2D onGround;

    Vector2 moveDirection = Vector2.zero;

    private void OnEnable()
    {
        InputAction.Enable();
    }
    private void OnDisable()
    {
        InputAction.Disable();
    }

    void Start()
    {
        //Sprite idleSprite = Resources.Load<Sprite>("Assets/Assets/kitten02_idle_02.png");
        //Sprite jumpSprite = Resources.Load<Sprite>("Assets/Assets/kitten02_jump.png");
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/kitten02_jump");
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        //float moveY = Input.GetAxis("Vertical");

        onGround = Physics2D.CircleCast(transform.position, 0.65f, Vector2.down, 0.1f);
        //Debug.Log(onGround.collider.name);

        //moveDirection = new Vector2(moveX,moveY);
        moveDirection = InputAction.ReadValue<Vector2>();

        RB.linearVelocityX = moveDirection.x * SPEED;

        if (onGround && RB.linearVelocityY <= 0)
        {
            if (onGround.collider.CompareTag("Unstable Platform"))
            {
                RB.linearVelocityY = JUMP_POWER;
                Destroy(onGround.collider.gameObject);
            }
            else if (onGround.collider.CompareTag("Boost Platform"))
            {
                RB.linearVelocityY = 20f;
            }
            else if (onGround.collider.CompareTag("Spiky Platform"))
            {
                Destroy(gameObject);
                FindFirstObjectByType<gameOverEvent>().showGameOverScreen(true);
            }
            else
            {
                RB.linearVelocityY = JUMP_POWER;
            }
        }
        else if (onGround && RB.linearVelocityY <= 5)
        {
            if (onGround.collider.CompareTag("Spiky Platform"))
            {
                Destroy(gameObject);
                FindFirstObjectByType<gameOverEvent>().showGameOverScreen(true);
            }
        }

        if (moveDirection.x < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        } else if (moveDirection.x > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    bool _onGround = gameObject.GetComponent<PlayerControls>().onGround;

    //    if (_onGround && RB.linearVelocityY <= 0)
    //    {
    //        if (collision.transform.CompareTag("Unstable Platform"))
    //        {
    //            RB.linearVelocityY = JUMP_POWER;
    //            Destroy(collision.gameObject);
    //        }
    //        //else if (collision.transform.CompareTag("Boost Platform"))
    //        //{
    //        //    RB.linearVelocityY = 20f;
    //        //}
    //        else
    //        {
    //            RB.linearVelocityY = JUMP_POWER;
    //        }
    //    }
    //}
}
