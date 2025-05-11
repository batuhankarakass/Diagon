using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public float health = 100f;
    public float damage = 10f;
    protected bool colliderBusy = false;

    public virtual void DealDamage(GameObject player)
    {
        player.GetComponent<PlayerManager>().GetDamage(damage);
    }

    public virtual void GetDamage(float damage)
    {
        health = Mathf.Max(health - damage, 0f);
        AmIDead();
    }

    protected virtual void AmIDead()
    {
        if (health <= 0f)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player" && !colliderBusy)
        {
            colliderBusy = true;
            DealDamage(other.gameObject);
        }
        else if (other.CompareTag("Bullet"))
        {
            GetDamage(other.GetComponent<BulletManager>().bulletDamage);
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            colliderBusy = false;
        }
    }
}


