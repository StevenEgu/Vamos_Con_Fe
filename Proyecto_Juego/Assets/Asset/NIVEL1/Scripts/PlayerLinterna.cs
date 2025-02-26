using UnityEngine;
using UnityEngine.UI;  // Necesario para trabajar con botones de UI
using System.Collections;  // Asegúrate de incluir este "using" para trabajar con coroutines

public class PlayerLinterna : MonoBehaviour
{
    public GameObject linternaObject; // GameObject que contiene la luz (así puedes activar o desactivar el objeto completo)
    private bool tieneLinterna = false;
    private bool linternaEncendida = false;
    private Coroutine parpadeoCoroutine;

    [Header("Configuración de Parpadeo")]
    public float tiempoEntreParpadeos = 5f; // Tiempo en segundos entre cada parpadeo (ajustable en el Inspector)

    public Button botonLinterna;  // Referencia al botón de la UI que el jugador presionará para recoger la linterna

    void Start()
    {
        // Verificamos que la linternaObject esté asignada
        if (linternaObject != null)
        {
            linternaObject.SetActive(false); // Apagamos el GameObject al inicio
        }
        else
        {
            Debug.LogWarning("Linterna Object no asignado en el Inspector.");
        }

        // Si el botón es asignado, conectamos el evento al método "RecogerLinterna"
        if (botonLinterna != null)
        {
            botonLinterna.onClick.AddListener(RecogerLinterna);
        }
        else
        {
            Debug.LogWarning("El botón de linterna no está asignado.");
        }
    }

    void Update()
    {
        // Solo si tienes la linterna, podrás activarla/desactivarla con la tecla Q
        if (tieneLinterna && Input.GetKeyDown(KeyCode.Q))
        {
            linternaEncendida = !linternaEncendida;

            if (linternaEncendida)
            {
                // Detener cualquier parpadeo anterior
                if (parpadeoCoroutine != null)
                    StopCoroutine(parpadeoCoroutine);

                // Iniciar el parpadeo con la linterna encendida
                parpadeoCoroutine = StartCoroutine(ParpadeoInicialYContinuo());
            }
            else
            {
                // Detener cualquier parpadeo y apagar la linterna
                if (parpadeoCoroutine != null)
                    StopCoroutine(parpadeoCoroutine);

                linternaObject.SetActive(false); // Desactiva el GameObject de la linterna
            }
        }
    }

    // Método para activar la linterna cuando se hace clic en el botón
    private void RecogerLinterna()
    {
        if (!tieneLinterna) // Si no tienes la linterna aún
        {
            tieneLinterna = true;
            botonLinterna.gameObject.SetActive(false); // Desactiva el botón después de hacer clic
            linternaObject.SetActive(true); // Activa el GameObject de la linterna
        }
    }

    private IEnumerator ParpadeoInicialYContinuo()
    {
        // Verificar que linternaObject no sea null
        if (linternaObject == null)
        {
            Debug.LogWarning("Linterna Object es null, no se puede continuar con el parpadeo.");
            yield break;  // Detener la corrutina si el GameObject de la linterna no está asignado
        }

        // 🔥 Parpadeo inicial (3 destellos)
        for (int i = 0; i < 3; i++)
        {
            linternaObject.SetActive(false);
            yield return new WaitForSeconds(0.1f);
            linternaObject.SetActive(true);
            yield return new WaitForSeconds(0.1f);
        }

        // 🔥 Parpadeo ocasional mientras esté encendida
        while (linternaEncendida)
        {
            yield return new WaitForSeconds(tiempoEntreParpadeos); // Espera el tiempo configurado

            // Hace 2-3 parpadeos aleatorios
            int numParpadeos = Random.Range(2, 4);
            for (int i = 0; i < numParpadeos; i++)
            {
                linternaObject.SetActive(false);
                yield return new WaitForSeconds(0.1f);
                linternaObject.SetActive(true);
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
