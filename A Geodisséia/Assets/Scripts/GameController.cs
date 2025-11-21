using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject gameObject;
    public static GameController instance;
    public GameObject player1, player2;
    public Transform checkpoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

   // public void GameOver()
    //{
      //  gameOver.SetActive(true);
    //}

    public void Respawn()
    {
        player1.transform.position = checkpoint.position;
        player2.transform.position = checkpoint.position;
        Debug.Log("Players no checkpoint");
    }
}
