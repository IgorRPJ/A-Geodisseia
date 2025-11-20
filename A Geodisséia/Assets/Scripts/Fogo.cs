using UnityEngine;

public class Fogo : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Trina") || other.CompareTag("Quadrium"))
        {
            Debug.Log("Player tocou no fogo!");

            Player1 p1 = other.GetComponent<Player1>();
            if (p1 != null)
                p1.Morrer();

            Player2 p2 = other.GetComponent<Player2>();
            if (p2 != null)
                p2.Morrer();
        }
    }
}