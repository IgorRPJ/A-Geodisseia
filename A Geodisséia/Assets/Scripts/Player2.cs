using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player2 : MonoBehaviour
{

    public int tangrams = 0;
    public TextMeshProUGUI textoUI;

    public float velocidade = 5;
    Rigidbody2D rb;

    public float JumpForce;
    public bool isJumping;
    public bool DoubleJump;

    private Animator anim;
    private SpriteRenderer spriter;

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
            textoUI.text = "P2: " + tangrams;
    }

    void DetectarChao()
    {
        isJumping = !Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        if (!isJumping)
            DoubleJump = true;
    }

    void Andar()
    {
        float velAtual = rb.linearVelocity.y;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.linearVelocity = new Vector2(velocidade, velAtual);
            spriter.flipX = false;
            anim.SetBool("Move", true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.linearVelocity = new Vector2(-velocidade, velAtual);
            spriter.flipX = true;
            anim.SetBool("Move", true);
        }
        else
        {
            rb.linearVelocity = new Vector2(0, velAtual);
            anim.SetBool("Move", false);
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (!isJumping)
            {
                rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
                anim.SetBool("Pulo", true);
            }
            else if (DoubleJump)
            {
                rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
                DoubleJump = false;
                anim.SetBool("Pulo", true);
            }
        }

        if (!isJumping)
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
        Debug.Log("Player2 morreu!");
        gameObject.SetActive(false);
        Invoke(nameof(RecarregarCena), 0.5f);
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
        escudoVisual.SetActive(true);

        Invoke(nameof(DesativarPowerUp), 10f);
    }

    void DesativarPowerUp()
    {
        powerUpAtivo = false;
        escudoVisual.SetActive(false);
        moedas = 0;
    }
}