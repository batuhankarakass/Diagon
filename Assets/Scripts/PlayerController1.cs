using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRb;
    Animator playerAnimator;

    public float moveSpeed = 5f;
    public float jumpSpeed = 7f;
    public float jumpCooldown = 0.25f;
    private float nextJumpTime;

    bool facingRight = true;

    public Transform spawnPoint;
    public Transform groundCheckPosition;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundCheckLayer;
    public bool isGrounded = false;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();

        if (spawnPoint != null)
        {
            transform.position = spawnPoint.position;
        }
    }

    void Update()
    {
        HorizontalMove();
        OnGroundCheck();
        HandleFlip();

        
        if (Input.GetButtonDown("Jump") && isGrounded && Time.time > nextJumpTime)
        {
            nextJumpTime = Time.time + jumpCooldown;
            Jump();
        }

      
    }

    void HorizontalMove()
    {
        float moveInput = Input.GetAxis("Horizontal");
        playerRb.linearVelocity = new Vector2(moveInput * moveSpeed, playerRb.linearVelocity.y);

        
        playerAnimator.SetFloat("playerSpeed", Mathf.Abs(moveInput));
    }

    void HandleFlip()
    {
        if ((playerRb.linearVelocity.x > 0 && !facingRight) || (playerRb.linearVelocity.x < 0 && facingRight))
        {
            facingRight = !facingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    void Jump()
    {
        playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, jumpSpeed);
    }

    void OnGroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundCheckLayer);
        playerAnimator.SetBool("isGroundedAnim", isGrounded);
    }
}
