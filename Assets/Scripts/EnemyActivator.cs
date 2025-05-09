using UnityEngine;

public class EnemyActivator : MonoBehaviour
{
    public JumpEnemy enemyToActivate;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enemyToActivate.Activate();
        }
    }
}