using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    public delegate void CoinCollectedAction();
    public static event CoinCollectedAction OnCoinCollected;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player has collided with the coin
        if (other.CompareTag("Player"))
        {
            // Collect the coin
            CollectCoin();

            // Trigger the coin collected event
            OnCoinCollected?.Invoke();
        }
    }

    private void CollectCoin()
    {
        // Play a sound effect, add score, or perform any other desired action upon collecting a coin
        Debug.Log("Coin collected!");

        // Destroy the coin object
        Destroy(gameObject);
    }
}



