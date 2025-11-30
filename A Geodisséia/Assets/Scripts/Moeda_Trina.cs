using UnityEngine;

public class Moeda_Trina : MonoBehaviour
{
    public GameObject somMoedaPrefab;

    void OnTriggerEnter2D(Collider2D collider)
    {
        Player1 p1 = collider.GetComponent<Player1>();

        if (p1 != null)
        {
            p1.ColetarMoeda();

            // Instancia o som sem ser filho da moeda
            GameObject som = Instantiate(somMoedaPrefab, transform.position, Quaternion.identity);
            Destroy(som, 2f); // destrói só o som depois

            Destroy(gameObject); // destrói a moeda separadamente
        }
    }
}
