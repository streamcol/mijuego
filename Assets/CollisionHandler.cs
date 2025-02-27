using UnityEngine;

public class WallCollision : MonoBehaviour
{
    public int maxCollisions = 3;
    private int collisionCount = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall")) // Verifica si el objeto tiene la etiqueta "Wall"
        {
            collisionCount++;
            Debug.Log("Has chocado con un muro. Intentos: " + collisionCount);

            if (collisionCount >= maxCollisions)
            {
                Debug.Log("¡Has perdido!");
                Destroy(gameObject); // Elimina el jugador
            }
        }
    }
}
