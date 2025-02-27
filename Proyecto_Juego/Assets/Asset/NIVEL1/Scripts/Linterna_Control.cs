using UnityEngine;
using UnityEngine.UI; // Aseg�rate de tener la referencia a UI
using UnityEngine.Rendering.Universal;
using System.Collections; // Necesario para las corrutinas

public class LinternaControl : MonoBehaviour
{
    public GameObject panel; // El panel que quieres cerrar
    public GameObject boton; // El bot�n que quieres destruir
    public Light2D linterna; // El Light2D (linterna) que quieres activar
    public Button botonDesactivado; // Referencia al bot�n desactivado que quieres activar
    private bool linternaEncendida = false; // Estado de la linterna
    private bool parpadeando = false; // Indica si la linterna est� parpadeando

    // Variables p�blicas para el inspector
    public float tiempoEsperaParpadeo = 0.5f; // Tiempo entre cada parpadeo (modificable en el inspector)
    public int cantidadDeParpadeos = 2; // Cantidad de parpadeos (modificable en el inspector)

    void Start()
    {
        // Aseguramos que la linterna est� apagada al inicio
        linterna.enabled = false;

        // Aseguramos que el bot�n desactivado est� inicialmente desactivado
        if (botonDesactivado != null)
        {
            botonDesactivado.gameObject.SetActive(false); // Desactivar el bot�n inicialmente
        }
    }

    void Update()
    {
        // Si la linterna est� activada, presionar Q alterna el estado de la linterna
        if (linternaEncendida && Input.GetKeyDown(KeyCode.Q) && !parpadeando)
        {
            ToggleLinterna(); // Alternar el estado de la linterna
        }
    }

    // Funci�n que se llama al presionar el bot�n
    public void ActivarLinternaYCerrarPanel()
    {
        // Destruir el bot�n
        Destroy(boton);

        // Desactivar el panel
        panel.SetActive(false);

        // Activar la linterna
        linterna.enabled = true;

        // Establecer la linterna como encendida
        linternaEncendida = true;

        // Activar el bot�n desactivado
        if (botonDesactivado != null)
        {
            botonDesactivado.gameObject.SetActive(true); // Activar el bot�n desactivado
        }

        // Comenzar el parpadeo (si no est� ya parpadeando)
        StartCoroutine(ParpadearLinterna());
    }

    // Funci�n que enciende o apaga la linterna
    private void ToggleLinterna()
    {
        // Alternar el estado de la linterna
        linterna.enabled = !linterna.enabled;
    }

    // Corutina para hacer que la linterna parpadee
    private IEnumerator ParpadearLinterna()
    {
        // Evitar que se inicie otro parpadeo mientras ya est� ocurriendo
        parpadeando = true;

        for (int i = 0; i < cantidadDeParpadeos; i++) // Hacer los parpadeos configurados
        {
            linterna.enabled = false; // Apagar la linterna
            yield return new WaitForSeconds(tiempoEsperaParpadeo); // Esperar el tiempo configurado

            linterna.enabled = true; // Encender la linterna
            yield return new WaitForSeconds(tiempoEsperaParpadeo); // Esperar el tiempo configurado
        }

        // Una vez terminado el parpadeo, podemos permitir m�s cambios de estado
        parpadeando = false;
    }
}
