using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    public Transform spawnPoint; // Asigna el punto de reaparici�n en el Inspector
    public GameObject player; // Arrastra el jugador aqu� en el Inspector

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.transform.position = spawnPoint.position; // Mueve al jugador al spawnPoint
        }
    }
}

