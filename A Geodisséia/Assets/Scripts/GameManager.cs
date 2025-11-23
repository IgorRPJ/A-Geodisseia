using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int tangrams = 0;
    public int totalTangrams = 7;

    public TextMeshProUGUI textoUI;

   // public int Lives; quantas vidas tem o jogador

    public string Fase1; //nome da fase1

    //public GameObject LastCheckpoint; ultimo checkpoint
    public Player1 Player1; //quem é o jogador para mandar
    public Player2 Player2;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

     public void AddTangram()
    {
        tangrams++;
        AtualizarUI();
    }

    void AtualizarUI()
    {
        if (textoUI != null)
            textoUI.text = $"{tangrams}/{totalTangrams}";
    }

    private void Start()
    {
       LoadMainMenu(); //carrega o menu 
    }

    private void Update()
    {
        //if (Keyboard.current.spaceKey.wasPressedThisFrame && Lives <0)
        //{
           // LoadNextLevel(); //se estiver sem vidas quando apertar espaço, carrega próxima fase ou reinicia
        //}
    }

    // public void ProcessDeath()
    // {
    //     Lives--;
    //     HUDObserverManager.LivesChangedChannel(Lives);
    //     HUDObserverManager.PlayerDeath(false);
        
    //     if (Lives < 0)
    //     {
    //         LoadGameOver();
    //     }
    //     else
    //     {
    //         ResetCurrentLevel();
    //     }
    // }

    // public void LoadNextLevel()
    // {
    //     if (Lives >= 0)
    //     {
    //         HUDObserverManager.PlayerVictory(false);
    //         if(SceneManager.GetActiveScene().name == levelName) LoadLevel2();
    //         if(SceneManager.GetActiveScene().name == "Level2") LoadLevel1();
    //     }
    //     else
    //     {
    //         if (SceneManager.GetActiveScene().name == "GameOver")
    //         {
    //            LoadMainMenu();
    //            // Lives = 3;
    //            // HUDObserverManager.LivesChangedChannel(Lives);
    //         }
    //     }
        
    // }

    // public void ResetCurrentLevel()
    // {
    //     if(LastCheckpoint == null)
    //         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //     else
    //     {
    //         PlayerController.transform.position = LastCheckpoint.transform.position;
    //         PlayerController.ResetPlayer();
    //     }
        
    // }

    // public void LoadLevel1()
    // {
    //     SceneManager.LoadScene(levelName);
    // }
    
    // public void LoadLevel2()
    // {
    //     SceneManager.LoadScene("Level2");
    // }

    // public void LoadGameOver()
    // {
    //     HUDObserverManager.ActivateHUD(false);
    //     SceneManager.LoadScene("GameOver");
    // }

    // public void AddLife(int value)
    // {
    //     Lives += value;
    //     HUDObserverManager.LivesChangedChannel(Lives);
    // }

    public void LoadMainMenu()
    {
       //ceneManager.LoadSceneAsync("Initialize").completed += (op) => { SceneManager.LoadScene("MainMenu"); };
        SceneManager.LoadScene("Menu");
    }

    // public void InitializeGame()
    // {
    //     HUDObserverManager.ActivateHUD(true);
    //     HUDObserverManager.LivesChangedChannel(Lives);
    //     Lives = 3;
    //     HUDObserverManager.LivesChangedChannel(Lives);
    // }

    // public void ProcessCheckpoint(GameObject otherGameObject)
    // {
    //     if (LastCheckpoint == null)
    //     {
    //         LastCheckpoint = otherGameObject;
    //         LastCheckpoint.GetComponent<Animator>().Play("Active");
    //         PlayerController.ValidCheckpointSound();
    //     } 
    //     else if (otherGameObject != LastCheckpoint)
    //     {
    //         LastCheckpoint.GetComponent<Animator>().Play("Off");

    //         LastCheckpoint = otherGameObject;
    //         LastCheckpoint.GetComponent<Animator>().Play("Active");
    //         PlayerController.ValidCheckpointSound();
    //     }
    // }
}