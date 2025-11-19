using UnityEngine;

public class Moeda_Quadrium : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        Player2 p2 = collider.GetComponent<Player2>();

        if (p2 != null)
        {
            p2.ColetarMoeda();
            Destroy(gameObject);
        }
    }
}
