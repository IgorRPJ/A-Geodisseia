using UnityEngine;

public class Moeda_Quadrium : MonoBehaviour
{
    public GameObject somMoedaPrefab;

    void OnTriggerEnter2D(Collider2D collider)
    {
        Player2 p2 = collider.GetComponent<Player2>();

        if (p2 != null)
        {
            p2.ColetarMoeda();

            GameObject som = Instantiate(somMoedaPrefab, transform.position, Quaternion.identity);
            Destroy(som, 2f);

            Destroy(gameObject);
        }
    }
}
