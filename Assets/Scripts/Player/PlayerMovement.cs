using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Movement bases
    private float horizontal;
    private float speed = 10f;
    private float jumpingPower = 12f;
    private bool isFacingRight = true;
    private bool doubleJumpEnabled = true;

    // Dashing System
    private bool dashEnabled = true;
    private bool isDashing;
    private float dashPower = 20f;
    private float dashTime = 0.2f;
    private float dashCooldown = 1f;

    [SerializeField] private Rigidbody2D rb; // Reference for player's rigidBody
    [SerializeField] private Transform groundCheck; // Position of player's foots
    [SerializeField] private LayerMask groundLayer; // Layer to collide and check for isGrounded
    [SerializeField] private TrailRenderer trailRenderer; // Reference to trail renderer   

    void Update()
    {
        if (isDashing)
            return;
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

        if (Input.GetKeyDown(KeyCode.LeftShift) && dashEnabled)
            StartCoroutine(Dash());

        Flip();
    }

    private void FixedUpdate()
    {
        if (isDashing)
            return;
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

    // Dashing coroutine
    private IEnumerator Dash()
    {
        dashEnabled = false;
        isDashing = true;
        float tmpGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashPower, 0f);
        trailRenderer.emitting = true;

        yield return new WaitForSeconds(dashTime);
        trailRenderer.emitting = false;
        rb.gravityScale = tmpGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        dashEnabled = true;
    }
}