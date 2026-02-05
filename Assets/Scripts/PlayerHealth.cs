using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private bool _isDead = false;
    
    [SerializeField] private float fallDeathY = -10f;
    
    public int playerHealthAmount;
    
    [SerializeField] private ParticleSystem damageEffect;
    
    private void Update()
    {
        CheckFallDeath();
    }
    public void TakeDamage(int damage)
    {
        playerHealthAmount -= damage;  // Decrease health by the damage amount
        Debug.Log("You are hit! Total health = " + playerHealthAmount);
        damageEffect.Play();

        if (playerHealthAmount <= 0)
        {
            Die();
        }
    }

    // Method to handle player death
    private void Die()
    {
        if (_isDead) return;
        
        _isDead = true;
        
        Debug.Log("You died!");
        Destroy(gameObject);  // Destroys the player object when health reaches 0
    }

    private void CheckFallDeath()
    {
        if (transform.position.y <= fallDeathY)
        {
            Die();
        }
    }
}