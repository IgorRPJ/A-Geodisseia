using UnityEngine;

public class CameraSegue : MonoBehaviour
{
       public Transform player1;
    public Transform player2;
    public float smoothSpeed = 0.125f;

    public float minX = -10f;
    public float maxX = 10f;
    public float minY = -5f;
    public float maxY = 5f;

    void LateUpdate()
    {
// Calcula o ponto médio entre os dois jogadores
        Vector3 middlePoint = (player1.position + player2.position) / 2f;
        Vector3 newPosition = new Vector3(middlePoint.x, middlePoint.y, transform.position.z);

        // Aplica os limites antes de mover a câmera
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

        // Move a câmera suavemente
        transform.position = Vector3.Lerp(transform.position, newPosition, smoothSpeed);
    }
}
