using UnityEngine;
using TMPro;

public class Aleatorio : MonoBehaviour
{
    //public void TextUptade(int value)
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player1") || collider.CompareTag("Player2"))
        {
            GameManager.Instance.AddTangram();
            Destroy(gameObject);
         }
    }
}