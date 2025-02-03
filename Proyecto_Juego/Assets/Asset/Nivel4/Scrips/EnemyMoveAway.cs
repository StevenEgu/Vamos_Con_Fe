using UnityEngine;

public class EnemyMoveWithAnimation : MonoBehaviour
{
    public Animator enemyAnimator;  // El Animator del enemigo
    public string animationTriggerName = "Leave";  // Nombre del trigger de animaci�n en el Animator
    public float moveSpeed = 5f;   // Velocidad de movimiento
    public Vector3 moveDirection = Vector3.left;  // Direcci�n en la que el enemigo se mover� (izquierda o derecha)

    private bool isMoving = false; // Para saber si el enemigo est� en movimiento

    // M�todo que se ejecuta cuando el bot�n es presionado
    public void OnButtonPress()
    {
        if (enemyAnimator != null)
        {
            // Activamos el trigger de la animaci�n
            enemyAnimator.SetTrigger(animationTriggerName);
            isMoving = true;  // Iniciar movimiento
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
