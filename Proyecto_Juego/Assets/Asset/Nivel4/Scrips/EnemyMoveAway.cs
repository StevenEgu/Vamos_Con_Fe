using UnityEngine;

public class EnemyMoveWithAnimation : MonoBehaviour
{
    public Animator enemyAnimator;  // El Animator del enemigo
    public string animationTriggerName = "Leave";  // Nombre del trigger de animación en el Animator
    public float moveSpeed = 5f;   // Velocidad de movimiento
    public Vector3 moveDirection = Vector3.left;  // Dirección en la que el enemigo se moverá (izquierda o derecha)

    private bool isMoving = false; // Para saber si el enemigo está en movimiento

    // Método que se ejecuta cuando el botón es presionado
    public void OnButtonPress()
    {
        if (enemyAnimator != null)
        {
            // Activamos el trigger de la animación
            enemyAnimator.SetTrigger(animationTriggerName);
            isMoving = true;  // Iniciar movimiento
        }
        else
        {
            Debug.LogError("El Animator no está asignado al enemigo.");
        }
    }

    // Update se ejecuta cada frame
    void Update()
    {
        if (isMoving)
        {
            // Mover al enemigo en la dirección especificada
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }
    }
}
