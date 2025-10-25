using UnityEngine;

public class Moeda_Quadrium : MonoBehaviour
{
    private CircleCollider2D mQ;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mQ = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Quadrium")
        {
            mQ.enabled = false;
            Destroy(gameObject);
        }
    }
}
