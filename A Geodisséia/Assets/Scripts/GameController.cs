using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject gameObject;
    public static GameController instance;
    public GameObject player1, player2;
    public Transform checkpoint;
    void Awake()
    {
        instance = this;
    }
    void Update()
    {

    }
    public void Respawn()
    {
        player1.transform.position = checkpoint.position;
        player2.transform.position = checkpoint.position;
        Debug.Log("Players no checkpoint");
    }
}