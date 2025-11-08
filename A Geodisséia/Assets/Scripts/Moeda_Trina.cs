using UnityEngine;

public class Moeda_Trina : MonoBehaviour
{
    private CircleCollider2D mT;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mT = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Trina")
        {
            mT.enabled = false;
            Destroy(gameObject);
        }
    }
}
