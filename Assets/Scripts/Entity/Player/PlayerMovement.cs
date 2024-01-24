using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // Movement bases
    private float horizontal;
    private float speed = 10f;
    private float jumpingPower = 15f;
    private bool isFacingRight = true;
    private bool doubleJumpEnabled = true;

    // Dashing System
    private bool dashEnabled = true;
    private bool isDashing;
    private float dashPower = 6f;
    private float dashTime = 0.2f;
    private float dashCooldown = 1f;

    // Wall Slide System
    private bool isWallSliding = false;
    private float wallSlideSpeed = 2f;

    // Wall Jump System
    private bool isWallJumping = false;
    private float wallJumpDirection;
    private float wallJumpTime = 0.2f;
    private float wallJumpCounter;
    private float wallJumpDuration = 0.4f;
    private Vector2 wallJumpPower = new Vector2(4f, 14f);

    // Graveyard spawn system
    public GameObject gravePrefab;
    public GameObject collectibleCounterRef;

    // Respawn System
    public static bool[] BigSoulsArray = new bool[3];
    public static int currentSoulNbr;
    public int tmpSoulNbr;
    public GameObject GameOverMenu; 

    [SerializeField] private Rigidbody2D rb; // Reference for player's rigidBody
    [SerializeField] private Transform groundCheck; // Position of player's foots
    [SerializeField] private LayerMask groundLayer; // Layer to collide and check for isGrounded
    [SerializeField] private TrailRenderer trailRenderer; // Reference to trail renderer
    [SerializeField] private Transform wallCheck; // Position of player's hand to grab walls
    [SerializeField] private LayerMask wallLayer; // Layer to collide and check if player is grabbing a wall
    [SerializeField] private Animator animator; // Animation component of the Player

    private void Start()
    {
        tmpSoulNbr = currentSoulNbr;
    }

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
                {
                    if (doubleJumpEnabled)
                    {
                        animator.SetBool("isDoubleJumping", true);
                    }
                    doubleJumpEnabled = false;
                }
            }
        }

        if (IsGrounded() && rb.velocity.y == 0f)
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isDoubleJumping", false);
        }
        else if(!IsGrounded())
            animator.SetBool("isJumping", true);

        animator.SetBool("isMoving", (rb.velocity.x * rb.velocity.x) >= 0.1f);

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        if (IsGrounded())
        {
            if (!doubleJumpEnabled)
                doubleJumpEnabled = true;
            if (Input.GetKeyDown(KeyCode.Q))
            {
                collectibleCounterRef = GameObject.Find("SoulCounterCanvas");
                if (collectibleCounterRef != null)
                {
                    CollectibleCount counter = collectibleCounterRef.GetComponentInChildren<CollectibleCount>();
                    if (counter.count > 0)
                    {
                        counter.decCount();
                        currentSoulNbr = counter.count;
                        Instantiate(gravePrefab, new Vector3(transform.position.x + (transform.localScale.x > 0 ? 1f : -1f), transform.position.y - 0.5f, transform.position.z), Quaternion.identity);
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && dashEnabled)
            StartCoroutine(Dash());

        WallSlide();
        WallJump();

        if (!isWallJumping)
            Flip();

    }

    private void FixedUpdate()
    {
        if (isDashing)
            return;
        if (!isWallJumping)
            rb.velocity = new Vector2((horizontal != 0f ? horizontal * speed : rb.velocity.x / 1.1f), rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private bool IsWalled()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    }

    private void WallSlide()
    {
        if (IsWalled() && !IsGrounded() && horizontal != 0f)
        {
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlideSpeed, float.MaxValue));
        } else
            isWallSliding = false;
    }

    private void WallJump()
    {
        if (isWallSliding)
        {
            isWallJumping = false;
            wallJumpDirection = -transform.localScale.x;
            wallJumpCounter = wallJumpTime;

            CancelInvoke(nameof(StopWallJumping));
        } else
        {
            wallJumpCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump") && wallJumpCounter > 0f)
        {
            isWallJumping = true;
            rb.velocity = new Vector2(wallJumpDirection * wallJumpPower.x, wallJumpPower.y);
            wallJumpCounter = 0f;

            if (transform.localScale.x != wallJumpDirection)
            {
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }
            Invoke(nameof(StopWallJumping), wallJumpDuration);
        }
    }

    private void StopWallJumping()
    {
        isWallJumping = false;
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

    // Death zone detection
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeathZone"))
        {
            currentSoulNbr = tmpSoulNbr;
            Death();
        }
    }

    private void Death()
    {
        currentSoulNbr = tmpSoulNbr;
        GameOverMenu.SetActive(true);
        Time.timeScale = 0f;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void respawn()  
    {
        Time.timeScale = 1f;
        LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadScene(String sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
