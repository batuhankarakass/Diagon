using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gecis : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            Time.timeScale = 1; 
            StartCoroutine(LoadSceneAsync()); 
        }
    }

    IEnumerator LoadSceneAsync()
    {
       
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Level2");

        
        while (!asyncLoad.isDone)
        {
            yield return null; 
        }

        Time.timeScale = 1;
    }
}