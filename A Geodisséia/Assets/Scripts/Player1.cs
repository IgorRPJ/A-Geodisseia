using UnityEngine;

public class Player1 : MonoBehaviour
{
    public float velocidade = 5;
    Rigidbody2D rb;

    public float JumpForce;
    public bool isJumping;
    public bool DoubleJump;

    //private Animator anim;

    //public bool estaNoChao;
    //public float forcaPulo = 10f;
    //public float raioChao = 0.2f;


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
        float movement = 0;

        if (Input.GetKey(KeyCode.D))
        {

            //movement = velocidade;
            //rb.AddForce(movement, ForceMode2D.Impulse);
            rb.linearVelocity = new Vector2(velocidade, rb.linearVelocity.y);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            //rb.AddForce(movement, ForceMode2D.Impulse);
            rb.linearVelocity = new Vector2(-velocidade, rb.linearVelocity.y);
        }

        else if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("você abaixou, clicou o botão S");
            //Vector2 movement = new Vector2(-0, velocidade);
        }

        else //ver se mantêm
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y); //para não dslizar
        }

    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {

            rb.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
            isJumping = false;
            //anim.SetBool("jump", true);

            Debug.Log("Tentando pular");

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false; //false quando encosta no chão
            //anim.SetBool("jump", false);
        }

    }

    //void OnCollisionExit2D(Collision2D collision)
    //{
    //    if(collision.gameObject.CompareTag("Ground"))
    //    {
    //        isJumping = false;
    //    }
    //}
}
