using UnityEngine;
using UnityEngine.SceneManagement;

public class PassarDeFase : MonoBehaviour
{
    [Header("Configuração")]
    public string Fase2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            SceneManager.LoadScene();
        }
    }
}