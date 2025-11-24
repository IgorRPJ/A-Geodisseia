using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player1 : MonoBehaviour
{

    public int tangrams = 0;
    public TextMeshProUGUI textoUI;

    [Header("Movimentação")]
    public float velocidade = 5f;
    public float JumpForce = 10f;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spriter;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float checkRadius = 0.2f;
    public LayerMask groundLayer;

    private bool isGrounded = false;

    [Header("Power Up")]
    public int moedas = 0;
    public int moedasNecessarias = 3;
    public bool powerUpAtivo = false;

    [Header("Player Check")]
    public LayerMask playerLayer;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriter = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        DetectarChao();
        Andar();
        Jump();
    }

    public void PegarTangram()
    {
        tangrams++;
        AtualizarUI();
    }

    void AtualizarUI()
    {
        if (textoUI != null)
            textoUI.text = "P1: " + tangrams;
    }

    void DetectarChao()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        if (!isGrounded)
        {
            Collider2D col = Physics2D.OverlapCircle(groundCheck.position, checkRadius);

            if (col != null && col.CompareTag("Player2"))
            {
                isGrounded = true; 
            }
        }
    }

    void Andar()
    {
        float velY = rb.linearVelocity.y;

        if (Input.GetKey(KeyCode.D))
        {
            rb.linearVelocity = new Vector2(velocidade, velY);
            spriter.flipX = false;
            anim.SetBool("Move", true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.linearVelocity = new Vector2(-velocidade, velY);
            spriter.flipX = true;
            anim.SetBool("Move", true);
        }
        else
        {
            rb.linearVelocity = new Vector2(0, velY);
            anim.SetBool("Move", false);
        }
    }

    void Jump()
    {
        bool onPlayer2 = Physics2D.OverlapCircle(groundCheck.position, checkRadius, playerLayer);

        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            anim.SetBool("Pulo", true);
        }

        if (Input.GetKeyDown(KeyCode.W) && onPlayer2)
        {
            rb.AddForce(Vector2.up * (JumpForce * 0.8f), ForceMode2D.Impulse);
            anim.SetTrigger("Pulo");
        }

        if (isGrounded)
            anim.SetBool("Pulo", false);
    }


    public void TomarDano(int dano, Vector2 origem)
    {
        if (anim != null)
            anim.SetTrigger("hit");

        Morrer();
    }

    public void Morrer()
    {
        Debug.Log("Player1 morreu!");
        gameObject.SetActive(false);
        Invoke(nameof(RecarregarCena), 1f);
    }

    void RecarregarCena()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void ColetarMoeda()
    {
        moedas++;

        if (moedas >= moedasNecessarias && !powerUpAtivo)
            AtivarPowerUp();
    }

    void AtivarPowerUp()
    {
        powerUpAtivo = true;
        velocidade *= 1.5f;

        Invoke(nameof(DesativarPowerUp), 10f);
    }

    void DesativarPowerUp()
    {
        velocidade /= 1.5f;
        powerUpAtivo = false;
        moedas = 0;
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
        }
    }
}