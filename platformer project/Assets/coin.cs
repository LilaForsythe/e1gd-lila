using UnityEngine;

public class coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            topdowncontroller player = collision.GetComponent<topdowncontroller>();
            player.coinsCollected++;
            Debug.Log($"Coins collected: {player.coinsCollected}");
            Destroy(gameObject);
        }
    }
}
