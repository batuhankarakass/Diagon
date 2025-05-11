using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerManager manager = other.GetComponent<PlayerManager>();
            manager.coins++;
            manager.ChangeValue();
            Destroy(gameObject); 
        }
    }
}
