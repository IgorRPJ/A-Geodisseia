using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float startPos;
    private Transform cam;

    public float parallaxEffect;

    void Start()
    {
        startPos = transform.position.x;
        cam = Camera.main.transform;
    }

    void Update()
    {
        float dist = cam.position.x * parallaxEffect;
        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);
    }
}
