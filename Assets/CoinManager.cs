using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    public int currentCoins = 0;
    public Text coinText; // UI Text'e bağlanacak

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void AddCoins(int amount)
    {
        currentCoins += amount;
        coinText.text = "Coins: " + currentCoins.ToString();
    }
}
