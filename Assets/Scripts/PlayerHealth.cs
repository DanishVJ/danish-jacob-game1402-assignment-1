using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float fallDeathY = -10f;
    
    public int playerHealthAmount;
    
    [SerializeField] private ParticleSystem damageEffect;

    private PlayerRespawn _playerRespawn;

    private void Awake()
    {
        _playerRespawn = GetComponent<PlayerRespawn>();
    }

    private void Update()
    {
        CheckFallDeath();
    }

    public void TakeDamage(int damage)
    {
        playerHealthAmount -= damage;
        Debug.Log("You are hit! Total health = " + playerHealthAmount);
        damageEffect.Play();

        if (playerHealthAmount <= 0)
        {
            HandleDeath();
        }
    }
    
    private void HandleDeath()
    {
      Debug.Log("You died!");
        
        _playerRespawn.Respawn();
    }

    private void CheckFallDeath()
    {
        if (transform.position.y <= fallDeathY)
        {
            HandleDeath();
        }
    }
}