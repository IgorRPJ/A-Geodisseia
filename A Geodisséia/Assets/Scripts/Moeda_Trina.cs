using UnityEngine;

public class Moeda_Trina : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        Player1 p1 = collider.GetComponent<Player1>();

        if (p1 != null)
        {
            p1.ColetarMoeda();
            Destroy(gameObject);
        }
    }
}
