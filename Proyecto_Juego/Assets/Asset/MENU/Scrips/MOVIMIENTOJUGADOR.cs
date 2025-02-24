using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOVIMIENTOJUGADOR : MonoBehaviour
{
    [HideInInspector] public int lives;
    [Header("Jugador")]
    [Space(10)]
    [TextArea(minLines: 2, maxLines: 4)]
    [SerializeField] private string DescripcionJugador;

    [Header("Movimiento")]
    [Range(2f, 20f)]
    [Space(10)]
    [SerializeField] private float VelocidadJugador = 3f;

    private Rigidbody2D playerRb;
    private Vector2 moveInput;
    private Animator animator; // Referencia al componente Animator

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // Obtener el componente Animator
    }

    // Update is called once per frame
    void Update()
    {
        // Obtener entrada de movimiento
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(moveX, moveY);

        // Actualizar el parámetro "Speed" en el Animator para la animación
        animator.SetFloat("Speed", Mathf.Abs(moveX)); // Solo se actualiza si hay movimiento horizontal

        // Voltear el personaje en función de la dirección
        if (moveX > 0) // Si el jugador se mueve hacia la derecha
        {
            transform.localScale = new Vector3(1, 1, 1); // Normal (mirando hacia la derecha)
        }
        else if (moveX < 0) // Si el jugador se mueve hacia la izquierda
        {
            transform.localScale = new Vector3(-1, 1, 1); // Volteado (mirando hacia la izquierda)
        }
    }

    private void FixedUpdate()
    {
        // Aplicar el movimiento
        playerRb.MovePosition(playerRb.position + moveInput * VelocidadJugador * Time.fixedDeltaTime);
    }
}
