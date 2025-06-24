using UnityEngine;

public class Player2 : MonoBehaviour
{public float velocidade = 5;
    Rigidbody2D rb;
        
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Andar1();
    }

    void Andar1()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector2 movement = new Vector2(velocidade, 0);
            //rb.AddForce(movement, ForceMode2D.Impulse);
            rb.linearVelocity = new Vector2(velocidade, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector2 movement = new Vector2(-velocidade, 0);
            //rb.AddForce(movement, ForceMode2D.Impulse);
            rb.linearVelocity = new Vector2(-velocidade, 0);
        }
       
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector2 movement = new Vector2(0, velocidade);
            //rb.AddForce(movement, ForceMode2D.Impulse);
            rb.linearVelocity = new Vector2(0, velocidade);
        }
       
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("Quadrium, clicou o botão S");
            Vector2 movement = new Vector2(-0, velocidade);
        }
    }
}
