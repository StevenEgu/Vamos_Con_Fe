using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOVELADOS : MonoBehaviour
{
    public float speed = 5f;  // Velocidad de movimiento del jugador
    private Rigidbody2D rb;
    private float moveInput;

    void Start()
    {
        // Obtén el componente Rigidbody2D del jugador
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Detecta la entrada del jugador (teclas de izquierda y derecha o A/D)
        moveInput = Input.GetAxis("Horizontal");

        // Mueve el jugador a la izquierda o derecha
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }
}
