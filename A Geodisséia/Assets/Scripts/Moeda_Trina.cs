using UnityEngine;

public class Moeda_Trina : MonoBehaviour
{
    private CircleCollider2D circle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        circle = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Trina")
        {
            circle.enabled = false;
            Destroy(gameObject);
        }
    }
}
