using UnityEngine;

public class TangramItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            TangramCounter.AddPoint();
            Destroy(gameObject);
        }
    }
}