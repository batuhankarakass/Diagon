using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float health;
    public float damage;

    bool colliderBusy = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.name == "Player" && !colliderBusy)
        {
            colliderBusy = true;
            other.GetComponent<PlayerManager>().GetDamage(damage);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            colliderBusy = false;
        }
    }

}



