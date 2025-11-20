using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float velocidade = 8f;
    private Vector2 direcao;

    public void SetDirection(Vector2 dir)
    {
        direcao = dir;
    }

    void Update()
    {
        transform.Translate(direcao * velocidade * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Player1 p1 = col.GetComponent<Player1>();
        Player2 p2 = col.GetComponent<Player2>();

        if (p1 != null)
        {
            if (p1.powerUpAtivo) 
            {
                Destroy(gameObject);
                return;
            }
            p1.TomarDano(999, transform.position);
            Destroy(gameObject);
            return;
        }

        if (p2 != null)
        {
            if (p2.powerUpAtivo)
            {
                Destroy(gameObject);
                return;
            }
            p2.TomarDano(999, transform.position);
            Destroy(gameObject);
            return;
        }

        if (col.CompareTag("Ground"))
            Destroy(gameObject);
    }

}
