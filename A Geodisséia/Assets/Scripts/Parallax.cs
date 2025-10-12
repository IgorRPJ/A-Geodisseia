using UnityEngine;

public class Parallax : MonoBehaviour
{

    private float length;
    private float PosicaoInicial;

    private Transform cam;

    public float ParallaxEffect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PosicaoInicial = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float Repos = cam.transform.position.x * (1 - ParallaxEffect);
        float Distance = cam.transform.position.x * ParallaxEffect;

        transform.position = new Vector3(PosicaoInicial + Distance, transform.position.y, transform.position.z);

        if (Repos > PosicaoInicial + length)
        {
            PosicaoInicial += length;
        }
        else if (Repos < PosicaoInicial - length)
        {
            PosicaoInicial -= length;
        }
    }
}
