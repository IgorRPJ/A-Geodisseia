using UnityEngine;

public class Fogo : MonoBehaviour
{
    private CircleCollider2D fire;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fire = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //void OnTriggerEnter2D(Collider2D collider)
    //{
        // if (collider.gameObject.tag == "Trina" + "Quadrium")
        //{
        //  fire.enabled = false;
        //  Destroy(gameObject);
        //}
    //}

    void OnTriggerEnter2D(Collider2D other) //tocou, chamou
    {

        if (other.CompareTag("Trina") || other.CompareTag("Quadrium"))
        {
            GameController.instance.Respawn();
            Debug.Log("tocou o fogo!");
        }
    }
}