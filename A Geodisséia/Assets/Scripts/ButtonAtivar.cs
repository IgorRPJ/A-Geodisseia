using UnityEngine;

public class ButtonTrigger2D : MonoBehaviour
{
    private PlatformDoor[] allPlatforms;

    private void Start()
    {
        allPlatforms = FindObjectsOfType<PlatformDoor>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            foreach (var p in allPlatforms)
                p.ActivatePlatform();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            foreach (var p in allPlatforms)
                p.DeactivatePlatform();
        }
    }
}