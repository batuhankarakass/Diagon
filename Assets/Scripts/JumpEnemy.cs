using UnityEngine;

public class JumpEnemy : BaseEnemy
{
    public float jumpForce = 10f;
    public float jumpCooldown = 2f;
    private float lastJumpTime;
    public Rigidbody2D rb;
    private Transform player;
    private bool isActive = false;
    private bool colliderBusy = false;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }

        if (rb == null)
            rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!isActive || player == null) return;

        if (Time.time > lastJumpTime + jumpCooldown)
        {
            float xDir = Mathf.Sign(player.position.x - transform.position.x); // -1 veya 1
            float xForce = xDir * 0.5f;  // Yatay kuvvet
            float yForce = 3f;           // Dikey kuvvet

            rb.AddForce(new Vector2(xForce, yForce) * jumpForce, ForceMode2D.Impulse);
            lastJumpTime = Time.time;
        }
    }

    public void Activate()
    {
        isActive = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);
        }

        if (collision.collider.CompareTag("Player") && !colliderBusy)
        {
            colliderBusy = true;
            DealDamage(collision.collider.gameObject);
        }

        if (collision.collider.CompareTag("Bullet"))
        {
            rb.linearVelocity = Vector2.zero; // Sekmeyi engelle
            BulletManager bullet = collision.collider.GetComponent<BulletManager>();
            if (bullet != null)
            {
                GetDamage(bullet.bulletDamage);
            }
            Destroy(collision.collider.gameObject); // Mermiyi yok et
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            colliderBusy = false;
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}