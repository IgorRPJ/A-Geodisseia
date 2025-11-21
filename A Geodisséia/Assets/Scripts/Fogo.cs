using UnityEngine;

public class Fogo : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            Player1 p1 = other.GetComponent<Player1>();
            Player2 p2 = other.GetComponent<Player2>();

            if (p1 != null)
            {
                p1.Morrer();
                Debug.Log("Player1 morreu no fogo!");
            }

            if (p2 != null)
            {
                p2.Morrer();
                Debug.Log("Player2 morreu no fogo!");
            }
        }
    }
    
}