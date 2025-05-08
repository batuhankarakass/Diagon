using UnityEngine;
using UnityEngine.SceneManagement;

public class Gecis : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Oyuncu tag'i varsa geçiş yap
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Level2");
           
        }
    }
}
