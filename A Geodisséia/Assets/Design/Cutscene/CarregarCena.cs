using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class CarregarCena : MonoBehaviour
{
    public string cenaParaCarregar;
    public PlayableDirector director;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        director.stopped += OnTimelineFinished;
    }

    // Update is called once per frame
    void OnTimelineFinished(PlayableDirector obj)
    {
        SceneManager.LoadScene(cenaParaCarregar);
    }
}
