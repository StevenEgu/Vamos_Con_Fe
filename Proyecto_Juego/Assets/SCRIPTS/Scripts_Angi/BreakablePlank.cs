using UnityEngine;

public class BreakablePlank : MonoBehaviour
{
    public int hitsToBreak = 3;       // N�mero de saltos necesarios para romper el tabl�n.
    public float minImpactForce = 5f; // Fuerza m�nima requerida en el eje Y para contar como "salto".
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
                    BreakPlank(); // Rompe el tabl�n si se alcanzan los impactos necesarios.
                }
            }
        }
    }

    private void BreakPlank()
    {
        // Acci�n cuando el tabl�n se rompe.
        Debug.Log("Plank broken!");
        Destroy(gameObject); // Destruye el tabl�n (puedes reemplazarlo con una animaci�n o efecto).
    }
}
