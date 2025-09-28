using UnityEngine;

public class Player2 : MonoBehaviour
{
    public float velocidade = 5;
    Rigidbody2D rb;

    public float JumpForce;
    public bool isJumping; //está no ar?
    public bool DoubleJump; //já usou pulo extra?

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

        if (Input.GetKey(KeyCode.RightArrow)) //Direita
        {
            rb.linearVelocity = new Vector2(velocidade, rb.linearVelocity.y);
        }
        else if (Input.GetKey(KeyCode.LeftArrow)) //Esquerda
        {
            rb.linearVelocity = new Vector2(-velocidade, rb.linearVelocity.y);
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow)) //S - Igual ao outro
        {
            Debug.Log("Quadrium abaixou, clicou o botão ");
        }

        else //para não deslizar
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y); //para não dslizar
        }

    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) //problema com isJumping só funciona as vezes e travado
        {
            if (!isJumping)
            {
                rb.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                isJumping = true;
                DoubleJump = true; //libera pulo duplo
                Debug.Log("pulou");
            }
            else if (DoubleJump)
            {
                rb.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                DoubleJump = false; //pulou já
                Debug.Log("pulo dobrado");
            }
        }
    }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isJumping = false; //chão
                DoubleJump = false; //reseta
            }
        }

       // void OnCollisionExit2D(Collision2D collision)
       // {
          //  if (collision.gameObject.CompareTag("Ground"))
           // {
         //       DoubleJump = true; //p1 infinite pulo tá false ein
       //     }
     //   }
 }