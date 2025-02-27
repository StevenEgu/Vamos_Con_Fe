using UnityEngine;
using UnityEngine.Rendering.Universal;
using TMPro; // Asegúrate de tener la referencia a TMP
using System.Collections; // Necesario para las corrutinas

public class LinternaControl : MonoBehaviour
{
    public GameObject panel; // El panel que quieres cerrar
    public GameObject boton; // El botón que quieres destruir
    public Light2D linterna; // El Light2D (linterna) que quieres activar
    public TextMeshProUGUI texto; // Referencia al componente TextMeshPro que se quiere activar
    private bool linternaEncendida = false; // Estado de la linterna
    private bool parpadeando = false; // Indica si la linterna está parpadeando

    // Variables públicas para el inspector
    public float tiempoEsperaParpadeo = 0.5f; // Tiempo entre cada parpadeo (modificable en el inspector)
    public int cantidadDeParpadeos = 2; // Cantidad de parpadeos (modificable en el inspector)

    void Start()
    {
        // Aseguramos que la linterna esté apagada al inicio
        linterna.enabled = false;

        // Aseguramos que el texto de TextMeshPro esté desactivado al inicio
        if (texto != null)
        {
            texto.gameObject.SetActive(false); // Desactivar texto inicialmente
        }
    }

    void Update()
    {
        // Si la linterna está activada, presionar Q alterna el estado de la linterna
        if (linternaEncendida && Input.GetKeyDown(KeyCode.Q) && !parpadeando)
        {
            ToggleLinterna(); // Alternar el estado de la linterna
        }
    }

    // Función que se llama al presionar el botón
    public void ActivarLinternaYCerrarPanel()
    {
        // Destruir el botón
        Destroy(boton);

        // Desactivar el panel
        panel.SetActive(false);

        // Activar la linterna
        linterna.enabled = true;

        // Establecer la linterna como encendida
        linternaEncendida = true;

        // Activar el TextMeshPro
        if (texto != null)
        {
            texto.gameObject.SetActive(true); // Activar el texto
        }

        // Comenzar el parpadeo (si no está ya parpadeando)
        StartCoroutine(ParpadearLinterna());
    }

    // Función que enciende o apaga la linterna
    private void ToggleLinterna()
    {
        // Alternar el estado de la linterna
        linterna.enabled = !linterna.enabled;
    }

    // Corutina para hacer que la linterna parpadee
    private IEnumerator ParpadearLinterna()
    {
        // Evitar que se inicie otro parpadeo mientras ya está ocurriendo
        parpadeando = true;

        for (int i = 0; i < cantidadDeParpadeos; i++) // Hacer los parpadeos configurados
        {
            linterna.enabled = false; // Apagar la linterna
            yield return new WaitForSeconds(tiempoEsperaParpadeo); // Esperar el tiempo configurado

            linterna.enabled = true; // Encender la linterna
            yield return new WaitForSeconds(tiempoEsperaParpadeo); // Esperar el tiempo configurado
        }

        // Una vez terminado el parpadeo, podemos permitir más cambios de estado
        parpadeando = false;
    }
}
