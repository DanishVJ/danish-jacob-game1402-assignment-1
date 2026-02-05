using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private int checkpointNumber;       // For debug messages
    [SerializeField] private Transform respawnPoint;     // Where the player will respawn
    private bool _isActivated = false;                   // Prevents re-triggering

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_isActivated) return;
        if (!other.CompareTag("Player")) return;

        PlayerRespawn player = other.GetComponent<PlayerRespawn>();
        if (player == null) return;

        player.UpdateRespawn(respawnPoint.position);     // Update player's respawn position
        _isActivated = true;

        Debug.Log($"Checkpoint {checkpointNumber} passed!");
    }
}