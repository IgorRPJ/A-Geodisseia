using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private string nomeDoLevelDeJogo;
    [SerializeField] private GameObject painelMenu;
    [SerializeField] private GameObject painelOpcoes;

    public void Jogar()
    {
        SceneManager.LoadScene(nomeDoLevelDeJogo); //1º fase

      //GameManager.Instance.LoadLevel1();
      //GameManager.Instance.InitializeGame();
    }

    public void AbrirOpcoes()
    {
        painelMenu.SetActive(false);
        painelOpcoes.SetActive(true);
    }

    public void FecharOpcoes()
    {
        painelMenu.SetActive(true);
        painelOpcoes.SetActive(false);
    }

    public void Sair()
    {
        Debug.Log("Saindo do Jogo...");
        Application.Quit();
    }
}
