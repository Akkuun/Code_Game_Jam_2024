using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Movement bases
    private float horizontal;
    private float speed = 10f;
    private float jumpingPower = 12f;
    private bool isFacingRight = true;
    private bool doubleJumpEnabled = true;


    [SerializeField] private Rigidbody2D rb; // Ref for player's rigidBody
    [SerializeField] private Transform groundCheck; // Position of player's foots
    [SerializeField] private LayerMask groundLayer; // Layer to collide and check for isGrounded

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded() || doubleJumpEnabled)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
                if (!IsGrounded())
                    doubleJumpEnabled = false;
            }
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        if (IsGrounded() && !doubleJumpEnabled)
            doubleJumpEnabled = true;

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}