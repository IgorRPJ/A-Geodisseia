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
            Instantiate(somMoedaPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
/*using UnityEngine;

public class Moeda_Quadrium : MonoBehaviour
{
     private AudioSource somMoeda;

    void OnTriggerEnter2D(Collider2D collider)
    {
        Player2 p2 = collider.GetComponent<Player2>();

        if (p2 != null)
        {
            p2.ColetarMoeda();
            somMoeda.Play();
            Destroy(gameObject);
        }
    }
}*/
