using UnityEngine;

public class PlatformDoor : MonoBehaviour
{
    [Header("Movimento")]
    public float upOffset = 3f;
    public float speed = 3f;

    Vector3 startPos;
    Vector3 targetUpPos;
    bool movingUp = false;
    bool movingDown = false;

    void Start()
    {
        startPos = transform.position;
        targetUpPos = startPos + Vector3.up * upOffset;
    }

    void Update()
    {
        if (movingUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetUpPos, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetUpPos) < 0.01f)
            {
                transform.position = targetUpPos;
                movingUp = false;
            }
        }
        else if (movingDown)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, startPos) < 0.01f)
            {
                transform.position = startPos;
                movingDown = false;
            }
        }
    }

    public void ActivatePlatform()
    {
        movingDown = false;
        movingUp = true;
    }

    public void DeactivatePlatform()
    {
        movingUp = false;
        movingDown = true;
    }
}
