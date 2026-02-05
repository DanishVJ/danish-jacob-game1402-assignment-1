using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector2 _respawnPosition;

    void Start()
    {
        _respawnPosition = transform.position; // default spawn location
    }

    public void UpdateRespawn(Vector2 newRespawnPosition)
    {
        _respawnPosition = newRespawnPosition;
    }
    
    public void Respawn()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.zero;

        transform.position = _respawnPosition;
    }
}