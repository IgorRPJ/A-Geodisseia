using UnityEngine;

public class Player1 : MonoBehaviour
{
    public float velocidade = 5;
    Rigidbody2D rb;

    public float JumpForce;
    public bool isJumping; //true= no ar, false= pode pular.

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Andar();
        Jump();
    }

    void Andar()
    {

        if (Input.GetKey(KeyCode.D)) //Direita
        {
            rb.linearVelocity = new Vector2(velocidade, rb.linearVelocity.y);
        }

        else if (Input.GetKey(KeyCode.A)) //Esquerda
        {
            rb.linearVelocity = new Vector2(-velocidade, rb.linearVelocity.y);
        }

        else if (Input.GetKeyDown(KeyCode.S)) //Baixo
        {
            Debug.Log("Trina abaixou, clicou o botão S");
            //Vector2 movement = new Vector2(-0, velocidade);
        }

        else //para não deslizar
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y); //para não dslizar
        }

    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && !isJumping) //coloquei isJumping pra ver se para o pulo infinito, mas ta o msm, ver os bool
        {
            rb.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
            isJumping = true;
            Debug.Log("pulou");

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false; //quando encosta no chão

        }

        void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isJumping = true; //p2 1 pulo tá true ein, saiu do chão
            }
        }
    }
}