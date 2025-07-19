using UnityEngine;

public class Player1 : MonoBehaviour
{
        public float velocidade = 5;
        Rigidbody2D rb;

        public float JumpForce;
        public bool isJumping;
        public bool DoubleJump;

        private Animator anim;

        public bool estaNoChao;
        public float forcaPulo = 10f;
        public float raioChao = 0.2f;

        
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
            Vector2 movementx = new Vector2(velocidade, 0);
           //rb.AddForce(movement, ForceMode2D.Impulse);
           rb.linearVelocity = new Vector2(velocidade, 0);
       }
       else if (Input.GetKey(KeyCode.A))
       {
           Vector2 movementx = new Vector2(-velocidade, 0);
           //rb.AddForce(movement, ForceMode2D.Impulse);
           rb.linearVelocity = new Vector2(-velocidade, 0);
       }
       
        else if (Input.GetKey(KeyCode.W)&&!isJumping)
       {
           Vector2 movementx = new Vector2(0, velocidade);
           //rb.AddForce(movement, ForceMode2D.Impulse);
           rb.linearVelocity = new Vector2(0, velocidade);
       }

       else if (Input.GetKeyDown(KeyCode.S))
       {
           Debug.Log("você abaixou, clicou o botão S");
           //Vector2 movement = new Vector2(-0, velocidade);
       }
    }

    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.W)&&!isJumping)
        {
            if(!isJumping)
            {
                rb.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                DoubleJump = true;
                //anim.SetBool("jump", true);
            }
            else
            {
                if(DoubleJump)
                {
                    rb.AddForce(new Vector2(0f, JumpForce * 2f), ForceMode2D.Impulse);
                    DoubleJump = true;
                }
            }
            
        }
    }

      void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isJumping = false;
            //anim.SetBool("jump", false);
        }
        
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isJumping = true;
        }
    }

}
