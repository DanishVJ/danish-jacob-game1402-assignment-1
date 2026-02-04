using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _currentTime;

    private float _speed = 1f;

    [SerializeField] private int cycleTime = 5;

    [SerializeField] private Transform leftPoint;
    
    [SerializeField] private Transform rightPoint;
    
    // Update is called once per frame
    void Update()
    {
        _currentTime += _speed * Time.deltaTime;

        if (_currentTime > cycleTime) _speed = -1f;
        if (_currentTime < 0f) _speed = 1f;
        
        float t = _currentTime / cycleTime;
        
        transform.position = Vector3.Lerp(leftPoint.position, rightPoint.position, t);
    }

    // Detect collision with the player
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
          
            PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null) 
            {
                playerHealth.TakeDamage(1);
            }
        }
    }
}