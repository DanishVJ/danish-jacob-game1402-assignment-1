using UnityEngine;

public class Coin : MonoBehaviour, ICollectible
{
    private int _amount = 1;
    public int GetAmount() => _amount;

    public void Collect()
    {
        Destroy(gameObject);
    }
}
