using UnityEngine;
using System.Collections;

public class PlayerLinterna : MonoBehaviour
{
    public UnityEngine.Rendering.Universal.Light2D linternaLuz; // Light 2D asignable en el Inspector
    private bool tieneLinterna = false;
    private bool linternaEncendida = false;
    private Coroutine parpadeoCoroutine;

    [Header("Configuración de Parpadeo")]
    public float tiempoEntreParpadeos = 5f; // Tiempo en segundos entre cada parpadeo (ajustable en el Inspector)

    void Start()
    {
        if (linternaLuz != null)
        {
            linternaLuz.enabled = false; // Apagamos la linterna al inicio
            linternaLuz.intensity = 1.5f; // Intensidad normal
            linternaLuz.pointLightOuterRadius = 5f; // Radio de la linterna
        }
        else
        {
            Debug.LogWarning("No se ha asignado el componente Light2D en el Inspector.");
        }
    }

    void Update()
    {
        if (tieneLinterna && Input.GetKeyDown(KeyCode.Q))
        {
            linternaEncendida = !linternaEncendida;

            if (linternaEncendida)
            {
                if (parpadeoCoroutine != null)
                    StopCoroutine(parpadeoCoroutine);

                parpadeoCoroutine = StartCoroutine(ParpadeoInicialYContinuo());
            }
            else
            {
                if (parpadeoCoroutine != null)
                    StopCoroutine(parpadeoCoroutine);

                linternaLuz.enabled = false;
            }
        }
    }

    private IEnumerator ParpadeoInicialYContinuo()
    {
        // 🔥 Parpadeo inicial (3 destellos)
        for (int i = 0; i < 3; i++)
        {
            linternaLuz.enabled = false;
            yield return new WaitForSeconds(0.1f);
            linternaLuz.enabled = true;
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
                linternaLuz.enabled = false;
                yield return new WaitForSeconds(0.1f);
                linternaLuz.enabled = true;
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Linterna"))
        {
            tieneLinterna = true;
            Destroy(other.gameObject); // Desaparece la linterna cuando la agarras
        }
    }
}
