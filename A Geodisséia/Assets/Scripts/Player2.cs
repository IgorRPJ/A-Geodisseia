using UnityEngine;

public class Player2 : MonoBehaviour
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

        if (Input.GetKey(KeyCode.RightArrow)) //D
        {
            Vector2 movementx = new Vector2(velocidade, 0);
            //rb.AddForce(movement, ForceMode2D.Impulse);
            rb.linearVelocity = new Vector2(velocidade, rb.linearVelocity.y); //continua a msm coisa, nn deixa de arrastar
        }
        else if (Input.GetKey(KeyCode.LeftArrow)) //A
        {
            Vector2 movementx = new Vector2(-velocidade, 0);
            //rb.AddForce(movement, ForceMode2D.Impulse);
            rb.linearVelocity = new Vector2(-velocidade, 0);
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow)) //S - Igual ao outro
        {
            Debug.Log("Quadrium abaixou, clicou o botão ");
            //Vector2 movementx = new Vector2(-0, velocidade);
        }

        else //ver se mantêm - igual p1
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y); //para não dslizar
        }

        //else if (Input.GetKey(KeyCode.UpArrow) && !isJumping) //o p1 tá sem isJumping - antes
        //{
            //Vector2 movementx = new Vector2(0, velocidade);
            //rb.AddForce(movement, ForceMode2D.Impulse);
            //rb.linearVelocity = new Vector2(0, 0);
        //}
        

    }

    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow)&&!isJumping) //problema com isJumping só funciona as vezes e travado
        {
            if(!isJumping)
            {
                Debug.Log("Tentando pular");
                rb.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                DoubleJump = true;
                //anim.SetBool("jump", true);
            }
            
            else
            {
                if (DoubleJump)
                {
                    rb.AddForce(new Vector2(0f, JumpForce * 2f), ForceMode2D.Impulse);
                    DoubleJump = false;
                }
            }
            
        }
    }

      void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            //anim.SetBool("jump", false);
        }
        
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isJumping = true; //p1 infinite pulo tá false ein
        }
    }
}
