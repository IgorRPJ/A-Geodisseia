using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed = 2f;
    public Transform pointA;
    public Transform pointB;

    private Vector3 target;
    private SpriteRenderer sprite;

    void Start()
    {
        target = pointB.position;
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target) < 0.1f)
        {
            target = (target == pointA.position) ? pointB.position : pointA.position;

            sprite.flipX = !sprite.flipX;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            other.GetComponent<Player1>().Morrer();
        }
        else if (other.CompareTag("Player2"))
        {
            other.GetComponent<Player2>().Morrer();
        }
    }
}
