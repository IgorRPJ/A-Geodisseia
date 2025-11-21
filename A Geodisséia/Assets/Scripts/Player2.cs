using UnityEngine;
using UnityEngine.SceneManagement;

public class Player2 : MonoBehaviour
{
    public float velocidade = 5;
    Rigidbody2D rb;

    public float JumpForce;
    public bool isJumping;
    public bool DoubleJump;
    private Animator anim;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float checkRadius = 0.2f;
    public LayerMask groundLayer;

    [Header("Power Up")]
    public int moedas = 0;
    public int moedasNecessarias = 3;
    public bool powerUpAtivo = false;
    public GameObject escudoVisual;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        isJumping = !Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        Andar();
        Jump();
    }

    void Andar()
    {
        float velAtual = rb.linearVelocity.y;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.linearVelocity = new Vector2(velocidade, velAtual);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.linearVelocity = new Vector2(-velocidade, velAtual);
        }
        else
        {
            rb.linearVelocity = new Vector2(0, velAtual);
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (!isJumping)
            {
                rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
                DoubleJump = true;
            }
            else if (DoubleJump)
            {
                rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
                DoubleJump = false;
            }
        }
    }

    public void TomarDano(int dano, Vector2 origem)
    {
        if (anim != null)
            anim.SetTrigger("hit");

        Morrer();
    }

    public void Morrer() { 
        Debug.Log("Player2 morreu!");
        gameObject.SetActive(false);
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
        escudoVisual.SetActive(true);
        Invoke(nameof(DesativarPowerUp), 10f);
    }

    void DesativarPowerUp()
    {
        velocidade /= 1.5f;
        powerUpAtivo = false;
        escudoVisual.SetActive(false);
        moedas = 0;
    }
}