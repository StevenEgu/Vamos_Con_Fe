using UnityEngine;
using UnityEngine.Rendering.Universal;  // Importa el espacio de nombres para Light2D

public class EnemyMoveStart : MonoBehaviour
{
    public Animator enemyAnimator;  // El Animator del enemigo
    public string animationTriggerName = "Leave";  // Nombre del trigger de animaci�n en el Animator
    public float moveSpeed = 5f;   // Velocidad de movimiento
    public Vector3 moveDirection = Vector3.left;  // Direcci�n en la que el enemigo se mover� (izquierda o derecha)

    public Light2D enemyLight;  // Referencia a la luz 2D del enemigo

    private bool isMoving = false; // Para saber si el enemigo est� en movimiento

    // M�todo que se ejecuta al iniciar la escena
    void Start()
    {
        if (enemyAnimator != null)
        {
            // Activamos el trigger de la animaci�n al iniciar la escena
            enemyAnimator.SetTrigger(animationTriggerName);
            isMoving = true;  // Iniciar movimiento

            // Activar la luz 2D
            if (enemyLight != null)
            {
                enemyLight.enabled = true;  // Encender la luz 2D
            }
            else
            {
                Debug.LogWarning("No se ha asignado la luz 2D al enemigo.");
            }
        }
        else
        {
            Debug.LogError("El Animator no est� asignado al enemigo.");
        }
    }

    // Update se ejecuta cada frame
    void Update()
    {
        if (isMoving)
        {
            // Mover al enemigo en la direcci�n especificada
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }
    }
}
