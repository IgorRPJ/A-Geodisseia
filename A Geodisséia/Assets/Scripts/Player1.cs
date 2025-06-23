using UnityEngine;

public class Player1 : MonoBehaviour
{
        public float velocidade = 5;
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
       if (Input.GetKeyUp(KeyCode.D))
       {
           Vector2 movement = new Vector2(velocidade, rb.velocity.x);
           velocidade = velocidade * 1;
       }
    }
}
