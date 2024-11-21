using UnityEngine;

public class BreakablePlank : MonoBehaviour
{
    public int hitsToBreak = 3;       // Número de saltos necesarios para romper el tablón.
    public float minImpactForce = 5f; // Fuerza mínima requerida en el eje Y para contar como "salto".
    private int currentHits = 0;     // Contador de impactos.

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica si el objeto que colisiona es el jugador.
        if (collision.gameObject.CompareTag("Player"))
        {
            // Verifica si la fuerza del impacto en el eje Y es suficiente.
            if (collision.relativeVelocity.y <= -minImpactForce)
            {
                currentHits++; // Incrementa el contador.

                Debug.Log("Plank hit by jump! Current hits: " + currentHits);

                if (currentHits >= hitsToBreak)
                {
                    BreakPlank(); // Rompe el tablón si se alcanzan los impactos necesarios.
                }
            }
        }
    }

    private void BreakPlank()
    {
        // Acción cuando el tablón se rompe.
        Debug.Log("Plank broken!");
        Destroy(gameObject); // Destruye el tablón (puedes reemplazarlo con una animación o efecto).
    }
}
