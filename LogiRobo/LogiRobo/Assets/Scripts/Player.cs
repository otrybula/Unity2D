using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpSpeed = 25f;
    [SerializeField] float climbSpeed = 3f;
    [SerializeField] Vector2 deathKick = new Vector2(0f, 15f);

    bool isAlive = true;

    Rigidbody2D myRigidbody;
    Animator myAnimator;
    BoxCollider2D myFeetCollider2D;
    CapsuleCollider2D myCollider2D;
    float gravityScale;


    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myCollider2D = GetComponent<CapsuleCollider2D>();
        myFeetCollider2D = GetComponent<BoxCollider2D>();

        transform.localScale = new Vector2(-1, 1f);
        gravityScale = myRigidbody.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive) { return; }
        Run(moveSpeed);
        Jump(jumpSpeed);
        Climbing(climbSpeed);
        FlipPlayerSprite();
        PlayerDeath();
    }

    private void Run(float moveSpeed)
    {
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(controlThrow * moveSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;
        bool playerMovingHorizontal = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("Walk", playerMovingHorizontal);
    }

    private void Climbing(float climbSpeed)
    {
        if (!myFeetCollider2D.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            myAnimator.SetBool("Climb", false);
            myRigidbody.gravityScale = gravityScale;
            return;
        }
        float controlThrow = CrossPlatformInputManager.GetAxis("Vertical");
        Vector2 climbVelocity = new Vector2(myRigidbody.velocity.x, controlThrow * climbSpeed);
        myRigidbody.velocity = climbVelocity;
        myRigidbody.gravityScale = 0f;

        bool playerHasVerticalSpeed = Mathf.Abs(myRigidbody.velocity.y) > Mathf.Epsilon;
        myAnimator.SetBool("Climb", playerHasVerticalSpeed);
    }

    private void Jump(float jumpSpeed)
    {
        if(!myFeetCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }

        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            Vector2 playerJumpVelocity = new Vector2(0f, jumpSpeed);
            myRigidbody.velocity += playerJumpVelocity;
            bool playerMovingVertical = Mathf.Abs(myRigidbody.velocity.y) > Mathf.Epsilon;
            myAnimator.SetBool("Jump", playerMovingVertical);
        }
    }

    private void FlipPlayerSprite()
    {
        bool playerMovingHorizontal = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        if (playerMovingHorizontal)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x) * -1, 1f);
        }

    }

    private void PlayerDeath()
    {
        if (myCollider2D.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards")))
        {
            myAnimator.SetTrigger("Death");
            GetComponent<Rigidbody2D>().velocity = deathKick;
            isAlive = false;
            FindObjectOfType<GameSession>().PlayerLifesControl();
        }
    }
}
