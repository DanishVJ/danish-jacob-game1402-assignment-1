using UnityEngine;

public class Collector : MonoBehaviour
{
    private int _totalCoins;
    private int _totalHealth;

    void OnTriggerEnter2D(Collider2D other)
    {
        ICollectible collectible = other.GetComponent<ICollectible>();
        if (collectible == null) return;

        // Determine type using tag
        if (other.CompareTag("Coin"))
        {
            _totalCoins += collectible.GetAmount();
            Debug.Log(collectible.GetAmount() + " coin collected! Total Coins: " + _totalCoins);
        }
        else if (other.CompareTag("Health"))
        {
            PlayerHealth playerHealth = GetComponent<PlayerHealth>();
            playerHealth.playerHealthAmount += collectible.GetAmount();
            Debug.Log(collectible.GetAmount() + " health collected! Total Health: " + playerHealth.playerHealthAmount);
        }

        collectible.Collect();
    }
}
