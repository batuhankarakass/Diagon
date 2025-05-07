using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public float bulletDamage, lifeTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
