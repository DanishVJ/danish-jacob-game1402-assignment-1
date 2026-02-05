using UnityEngine;

public class PlayerFootStep : MonoBehaviour
{
    [SerializeField] private ParticleSystem footStepEffect;

    [SerializeField] private string targetTag = "Ground";

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag(targetTag))
        {
            footStepEffect.Play();
        }
    }
}