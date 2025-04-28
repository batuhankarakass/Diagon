using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRb;
    Animator playerAnimator;
    public float moveSpeed = 1f;  // neden burda 1f yaptık bilmiyorum 5f?
    public float jumpSpeed = 1f, jumpFrequency, nextJumpTime;

    bool facingRight=true;

    public Transform groundCheckPosition;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;

    public bool isGrounded = false;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        HorizontalMove();
        OnGroundCheck();

        if (playerRb.linearVelocity.x < 0 && facingRight)
        {
            Flipface();
        }
        else if (playerRb.linearVelocity.x>0 && !facingRight) 
        {
            Flipface();
        }

        if (Input.GetAxis("Vertical") > 0 && isGrounded && (nextJumpTime < Time.timeSinceLevelLoad))
        {
            nextJumpTime = Time.timeSinceLevelLoad + jumpFrequency;
            Jump();
        }
    }

    void HorizontalMove()
    {
        playerRb.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, playerRb.linearVelocity.y);

        playerAnimator.SetFloat("playerSpeed", Mathf.Abs(playerRb.linearVelocity.x));
    }

    void Flipface()
    {
        facingRight = !facingRight;
        Vector3 tempLocalScale = transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale = tempLocalScale;


    }

    void Jump()
    {
        playerRb.AddForce(new Vector2(0f,jumpSpeed));
    }

    void OnGroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPosition.position,groundCheckRadius, groundCheckLayer);
        playerAnimator.SetBool("isGroundedAnim", isGrounded);  
    }

}
