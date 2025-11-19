using UnityEngine;

public class Boss : MonoBehaviour
{
    [Header("Vida")]
    public int vidaMax = 10;
    public int vidaAtual;

    [Header("Movimento")]
    public float velocidade = 3f;

    [Header("Ataque")]
    public GameObject projetil;
    public float tempoEntreAtaques = 0.8f;
    private float cooldown = 0f;

    void Start()
    {
        vidaAtual = vidaMax;
    }

    void Update()
    {
        Transform alvo = GetPlayerVivoMaisProximo();

        if (alvo == null)
            return;

        Mover(alvo);
        Atacar(alvo);
    }

    Transform GetPlayerVivoMaisProximo()
    {
        GameObject p1 = GameObject.FindWithTag("Player1");
        GameObject p2 = GameObject.FindWithTag("Player2");

        Transform alvo = null;
        float menorDist = Mathf.Infinity;

        if (p1 != null && p1.activeInHierarchy)
        {
            float dist = Vector2.Distance(transform.position, p1.transform.position);
            menorDist = dist;
            alvo = p1.transform;
        }

        if (p2 != null && p2.activeInHierarchy)
        {
            float dist = Vector2.Distance(transform.position, p2.transform.position);
            if (dist < menorDist)
            {
                menorDist = dist;
                alvo = p2.transform;
            }
        }

        return alvo;
    }

    void Mover(Transform alvo)
    {
        float distancia = Vector2.Distance(transform.position, alvo.position);
        float distanciaMinima = 4f;

        if (distancia > distanciaMinima)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                alvo.position,
                velocidade * Time.deltaTime
            );
        }
    }

    void Atacar(Transform alvo)
    {
        if (projetil == null)
        {
            Debug.LogError("Boss sem projetil atribuído!");
            return;
        }

        if (cooldown <= 0)
        {
            Vector2 direcao = (alvo.position - transform.position).normalized;

            GameObject tiro = Instantiate(
                projetil,
                transform.position,
                Quaternion.identity
            );

            Projectile proj = tiro.GetComponent<Projectile>();

            if (proj != null)
                proj.SetDirection(direcao);

            cooldown = tempoEntreAtaques;
        }
        else
        {
            cooldown -= Time.deltaTime;
        }
    }

    public void TomarDano(int dano)
    {
        vidaAtual -= dano;
        Debug.Log("Boss tomou dano! Vida = " + vidaAtual);

        if (vidaAtual <= 0)
        {
            Morrer();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Player1"))
            TomarDano(1);

        if (col.collider.CompareTag("Player2"))
            TomarDano(1);
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player1"))
        {
            TomarDano(1);
        }

        if (col.CompareTag("Player2"))
        {
            TomarDano(1);
        }
    }

    void Morrer()
    {
        Debug.Log("BOSS MORTO!");
        Destroy(gameObject);
    }
}
