using UnityEngine;
using TMPro;
public class TangramCounter : MonoBehaviour
{
    public static TangramCounter instance;

    public static int count = 0;

    [Header("Referência do Texto (TMPro)")]
    public TextMeshProUGUI counterText;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        UpdateText();
    }

    public static void AddPoint()
    {
        count++;
        instance.UpdateText();
    }

    private void UpdateText()
    {
        counterText.text = "Tangrams: " + count.ToString();
    }
}