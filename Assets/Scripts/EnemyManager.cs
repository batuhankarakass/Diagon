using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float health;
    public float damage;

    public float moveSpeed = 2f;
    public Transform leftPoint;
    public Transform rightPoint;

    private bool movingRight = true;
    private bool colliderBusy = false;

    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        if (movingRight)
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            if (transform.position.x >= rightPoint.position.x)
                movingRight = false;
        }
        else
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            if (transform.position.x <= leftPoint.position.x)
                movingRight = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player" && !colliderBusy)
        {
            colliderBusy = true;
            other.GetComponent<PlayerManager>().GetDamage(damage);
        }
        else if (other.CompareTag("Bullet"))
        {
            GetDamage(other.GetComponent<BulletManager>().bulletDamage);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            colliderBusy = false;
        }
    }

    public void GetDamage(float damage)
    {
        if ((health - damage) >= 0)
        {
            health -= damage;
        }
        else
        {
            health = 0;
        }
        AmIDead();
    }

    public void AmIDead()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}



