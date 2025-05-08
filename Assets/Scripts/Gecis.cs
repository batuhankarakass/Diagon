/*using UnityEngine;
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
*/


using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gecis : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Oyuncu tag'i varsa geçiş yap
        {
            Time.timeScale = 1; // Oyun hızını normal yap
            StartCoroutine(LoadSceneAsync()); // Asenkron sahne yükleme başlat
        }
    }

    IEnumerator LoadSceneAsync()
    {
        // Sahne yükleme işlemi başlatılır
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Level2");

        // Sahne yüklenene kadar bekleyin
        while (!asyncLoad.isDone)
        {
            yield return null; // Yeni frame'e geçmeden bekle
        }

        Time.timeScale = 1;
    }
}