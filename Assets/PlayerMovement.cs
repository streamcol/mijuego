using UnityEngine;
using UnityEngine.SceneManagement; // Para reiniciar la escena

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 200f;
    private CharacterController controller;
    private Vector3 moveDirection;
    private int hitCount = 0; // Contador de golpes contra muros
    private float gravity = 9.81f; // Gravedad

    void Start()
    {
        controller = GetComponent<CharacterController>();

        if (controller == null)
        {
            Debug.LogError("¡Falta CharacterController en " + gameObject.name + "! Agrégalo en el Inspector.");
            this.enabled = false;
        }
    }

    void Update()
    {
        if (controller == null) return;

        // Movimiento
        float moveZ = Input.GetAxis("Vertical");
        float rotateY = Input.GetAxis("Horizontal");

        moveDirection = transform.forward * moveZ * speed;

        // Aplicar gravedad
        if (!controller.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        controller.Move(moveDirection * Time.deltaTime);
        transform.Rotate(0, rotateY * rotationSpeed * Time.deltaTime, 0);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Wall"))
        {
            hitCount++;
            Debug.Log("Golpes contra el muro: " + hitCount);

            if (hitCount >= 3)
            {
                Debug.Log("¡Jugador eliminado! Reiniciando...");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}

