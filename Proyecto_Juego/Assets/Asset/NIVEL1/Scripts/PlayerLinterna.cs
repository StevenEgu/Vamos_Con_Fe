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
            Debug.Log("Linterna desactivada al inicio.");
        }
        else
        {
            Debug.LogWarning("Linterna Object no asignado en el Inspector.");
        }

        // Si el botón es asignado, conectamos el evento al método "RecogerLinterna"
        if (botonLinterna != null)
        {
            botonLinterna.onClick.AddListener(RecogerLinterna);
            Debug.Log("Botón de linterna asignado y evento conectado.");
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
            Debug.Log($"Tecla Q presionada. Linterna Encendida: {linternaEncendida}");

            if (linternaEncendida)
            {
                // Si la linterna se enciende, reiniciamos el parpadeo
                if (parpadeoCoroutine != null)
                {
                    StopCoroutine(parpadeoCoroutine);
                    Debug.Log("Corutina de parpadeo detenida.");
                }

                // Iniciar el parpadeo con la linterna encendida
                parpadeoCoroutine = StartCoroutine(ParpadeoInicialYContinuo());
                Debug.Log("Corutina de parpadeo iniciada.");
            }
            else
            {
                // Si la linterna se apaga, detenemos el parpadeo
                if (parpadeoCoroutine != null)
                {
                    StopCoroutine(parpadeoCoroutine);
                    Debug.Log("Corutina de parpadeo detenida.");
                }

                linternaObject.SetActive(false); // Desactiva el GameObject de la linterna
                Debug.Log("Linterna apagada.");
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
            Debug.Log("Linterna recogida. El botón de linterna se desactiva.");
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
        Debug.Log("Iniciando parpadeo inicial...");
        for (int i = 0; i < 3; i++)
        {
            linternaObject.SetActive(false);
            yield return new WaitForSeconds(0.1f);
            linternaObject.SetActive(true);
            yield return new WaitForSeconds(0.1f);
        }

        // 🔥 Parpadeo ocasional mientras esté encendida
        Debug.Log("Iniciando parpadeo continuo...");
        while (linternaEncendida)
        {
            yield return new WaitForSeconds(tiempoEntreParpadeos); // Espera el tiempo configurado

            // Hace 2-3 parpadeos aleatorios
            int numParpadeos = Random.Range(2, 4);
            Debug.Log($"Haciendo {numParpadeos} parpadeos aleatorios.");
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
