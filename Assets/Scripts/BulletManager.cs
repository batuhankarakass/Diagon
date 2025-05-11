using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public float bulletDamage;

    void Start()
    {
        Destroy(gameObject, 2f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Enemy"))
        {
           
 
            Destroy(gameObject);
        }
    }
}
