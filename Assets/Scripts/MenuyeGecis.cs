using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuyeGecis : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Oyuncu kapıya girerse
        {
            Time.timeScale = 1; // Oyun donmuşsa geri başlat
            StartCoroutine(LoadMenuScene());
        }
    }

    IEnumerator LoadMenuScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("menuScene"); // ya da index 0

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        Time.timeScale = 1;
    }
}
