using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENEMYMOVELADOS : MonoBehaviour
{
    public float speed = 3f;  // Velocidad del enemigo
    public float leftLimit;   // L�mite izquierdo de movimiento
    public float rightLimit;  // L�mite derecho de movimiento
    private bool movingRight = true;  // Determina si el enemigo se est� moviendo hacia la derecha

    void Update()
    {
        // Movimiento del enemigo a la derecha o izquierda
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);

            // Si el enemigo llega al l�mite derecho, cambia de direcci�n
            if (transform.position.x >= rightLimit)
            {
                movingRight = false;
                Flip();
            }
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);

            // Si el enemigo llega al l�mite izquierdo, cambia de direcci�n
            if (transform.position.x <= leftLimit)
            {
                movingRight = true;
                Flip();
            }
        }
    }

    // M�todo para girar al enemigo (opcional, para que cambie la direcci�n visual)
    void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;  // Invertir la escala en el eje X para que se vea al otro lado
        transform.localScale = localScale;
    }
}
