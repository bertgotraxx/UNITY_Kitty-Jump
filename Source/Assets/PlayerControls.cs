using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerControls : MonoBehaviour
{
    // Player's variables
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

    // Before start - player's sprite is the idle one, after game starts it changes to the "jumping" one
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/kitten02_jump");
    }

    void Update()
    {
        // Variable that contains input values responsible for horizontal (X coordinate) movement
        // float moveX = Input.GetAxis("Horizontal");

        // Invisible circle drawn around a player that detects, if player is on the platform or not
        onGround = Physics2D.CircleCast(transform.position, 0.65f, Vector2.down, 0.1f);
        // Variable that contains movement inputs (X & Y coordinates)
        moveDirection = InputAction.ReadValue<Vector2>();
        // Apply X velocity to player object by setting a value combined from player input
        // and value set in constant "SPEED"
        RB.linearVelocityX = moveDirection.x * SPEED;

        // "If" block that checks if player is on the platform and if player falls instead of going up
        if (onGround && RB.linearVelocityY <= 0)
        {
            // If player lands on unstable platform, then destroy the platform
            if (onGround.collider.CompareTag("Unstable Platform"))
            {
                RB.linearVelocityY = JUMP_POWER;
                Destroy(onGround.collider.gameObject);
            }
            // If player lands on boost platform, then give a one-time jumping boost
            else if (onGround.collider.CompareTag("Boost Platform"))
            {
                RB.linearVelocityY = 20f;
            }
            // If player lands on spiky platform, then destroy the player object and show "Game Over" screen
            else if (onGround.collider.CompareTag("Spiky Platform"))
            {
                Destroy(gameObject);
                FindFirstObjectByType<gameOverEvent>().showGameOverScreen(true);
            }
            // If player lands on basic platform, then just jump
            else
            {
                RB.linearVelocityY = JUMP_POWER;
            }
        }
        // Condition specially for preventing player object from accidental destroying
        // in case it collides with spiky platform while going up
        else if (onGround && RB.linearVelocityY <= 5)
        {
            if (onGround.collider.CompareTag("Spiky Platform"))
            {
                Destroy(gameObject);
                FindFirstObjectByType<gameOverEvent>().showGameOverScreen(true);
            }
        }

        // Flip player sprite that matches the movement direction (Left/Right)
        if (moveDirection.x < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        } else if (moveDirection.x > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
