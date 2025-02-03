using UnityEngine;
using UnityEngine.UI;

public class SliderControl : MonoBehaviour
{
    // Referencias a los objetos en el panel de control
    public Slider slider; // El slider en el panel
    public GameObject objectToHide; // El objeto que se esconderá cuando se presione el botón
    public GameObject objectToDestroy; // El objeto que se destruirá cuando el slider esté lleno
    public GameObject panel; // El panel que contiene el slider y otros elementos de control

    // Variables de control
    public float sliderIncrement = 0.1f; // Cuánto sube el slider por cada recogida
    public float maxSliderValue = 1f; // Valor máximo del slider (generalmente 1)

    private bool objectDestroyed = false; // Flag para saber si el objeto ya fue destruido

    void Start()
    {
        // Verificamos si el slider y el panel están asignados correctamente
        if (slider == null || panel == null)
        {
            Debug.LogError("Slider o Panel no asignados en el inspector.");
            return;
        }

        // Inicialmente deshabilitamos el slider y el panel
        slider.gameObject.SetActive(false);
        panel.SetActive(false); // Aseguramos que el panel esté oculto al principio
        slider.maxValue = maxSliderValue; // Aseguramos que el maxValue del slider sea el valor máximo deseado

        Debug.Log("Slider Inicializado. Valor máximo: " + maxSliderValue);
    }

    // Método que se llama cuando se presiona el botón para "recoger" el objeto
    public void OnObjectCollected()
    {
        if (objectDestroyed)
        {
            Debug.Log("El objeto ya fue destruido, no se puede recoger más.");
            return;
        }

        // Desactivamos el objeto (lo "recogemos")
        Debug.Log("Recogiendo el objeto. El objeto se desactivará.");
        objectToHide.SetActive(false);

        // Activamos el panel y el slider
        panel.SetActive(true); // Activamos el panel
        slider.gameObject.SetActive(true); // Activamos el slider

        // Pausamos el juego cuando se abre el panel
        Time.timeScale = 0f; // Pausamos el juego

        // Mostramos el valor del slider en la consola
        Debug.Log("Valor actual del Slider: " + slider.value);
    }

    // Método para actualizar el valor del slider
    public void SliderValue()
    {
        if (slider.value >= maxSliderValue)
        {
            Debug.Log("¡Slider lleno! Destruyendo el objeto...");
            DestroyObject();
        }
    }

    // Método para destruir el objeto cuando el slider está lleno
    private void DestroyObject()
    {
        if (!objectDestroyed)
        {
            Debug.Log("Destruyendo el objeto: " + objectToDestroy.name);
            Destroy(objectToDestroy); // Destruimos el objeto
            objectDestroyed = true; // Marcamos que el objeto fue destruido
            slider.gameObject.SetActive(false); // Desactivamos el slider
            panel.SetActive(false); // Desactivamos el panel
            Debug.Log("El objeto ha sido destruido.");
        }
        else
        {
            Debug.Log("El objeto ya fue destruido previamente.");
        }
    }

    // Método para cerrar el panel y reanudar el juego
    public void ClosePanel()
    {
        // Desactivamos el panel y el slider
        panel.SetActive(false);
        slider.gameObject.SetActive(false);

        // Reanudamos el juego cuando se cierra el panel
        Time.timeScale = 1f; // Reanudamos el juego
        Debug.Log("El panel se ha cerrado, el juego continúa.");
    }
}
