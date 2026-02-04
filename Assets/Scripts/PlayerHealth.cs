using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private bool _isDead = false;
    
    [SerializeField] private float fallDeathY = -10f;
    
    [SerializeField] private int health = 3;  // Non-static health variable for each player instance
    
    [SerializeField] private ParticleSystem damageEffect;
    // Method to take damage
    
    private void Update()
    {
        CheckFallDeath();
    }
    public void TakeDamage(int damage)
    {
        health -= damage;  // Decrease health by the damage amount
        Debug.Log("You are hit! Total health = " + health);
        damageEffect.Play();

        if (health <= 0)
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