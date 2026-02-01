using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private int value = 1; // How much this collectible adds

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Only react if the player collides
     //   if (other.CompareTag("Player"))
        {
            // Increase player's collectible count
           // PlayerController player = other.GetComponent<PlayerController>();
           // if (player != null)
            {
           //     player.AddCollectible(value);
            }

            // Remove the collectible from the scene
          //  Destroy(gameObject);
        }
    }
}