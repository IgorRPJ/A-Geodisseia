using UnityEngine;

public class ButtonTrigger2D : MonoBehaviour
{
    public PlatformDoor platform;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            platform.ActivatePlatform();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            platform.DeactivatePlatform();
        }
    }
}
