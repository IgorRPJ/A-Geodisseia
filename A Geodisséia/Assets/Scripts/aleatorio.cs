using UnityEngine;

public class Aleatorio : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        Player1 p1 = collider.GetComponent<Player1>();
        if (p1 != null)
        {
            Debug.Log("Player 1 pegou o item aleatório!");
            Destroy(gameObject);
            return;
        }

        Player2 p2 = collider.GetComponent<Player2>();
        if (p2 != null)
        {
            Debug.Log("Player 2 pegou o item aleatório!");
            Destroy(gameObject);
            return;
        }
    }
}
