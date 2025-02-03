using UnityEngine;
using UnityEngine.UI;

public class SliderControl : MonoBehaviour
{
    // Referencias a los objetos en el panel de control
    public Slider slider; // El slider en el panel
    public GameObject objectToHide; // El objeto que se esconder� cuando se presione el bot�n
    public GameObject objectToDestroy; // El objeto que se destruir� cuando el slider est� lleno

    // Variables de control
    public float sliderIncrement = 0.1f; // Cu�nto sube el slider por cada recogida
    public float maxSliderValue = 1f; // Valor m�ximo del slider (generalmente 1)

    private bool objectDestroyed = false; // Flag para saber si el objeto ya fue destruido

    void Start()
    {
        // Verificamos si el slider est� asignado correctamente
        if (slider == null)
        {
            Debug.LogError("Slider no asignado en el inspector.");
            return;
        }

        // Inicialmente deshabilitamos el slider
        slider.gameObject.SetActive(false);
       // slider.value = 0f; // Aseguramos que el slider comienza desde 0
        slider.maxValue = maxSliderValue; // Aseguramos que el maxValue del slider sea el valor m�ximo deseado

        Debug.Log("Slider Inicializado. Valor m�ximo: " + maxSliderValue);
    }

    // M�todo que se llama cuando se presiona el bot�n para "recoger" el objeto
    public void OnObjectCollected()
    {
        if (objectDestroyed)
        {
            Debug.Log("El objeto ya fue destruido, no se puede recoger m�s.");
            return;
        }

        // Desactivamos el objeto (lo "recogemos")
        Debug.Log("Recogiendo el objeto. El objeto se desactivar�.");
        objectToHide.SetActive(false);

        // Activamos el slider
        slider.gameObject.SetActive(true); // Activamos el slider
        //slider.value += sliderIncrement;   // Incrementamos el valor del slider

        // Mostramos el valor del slider en la consola
        Debug.Log("Valor actual del Slider: " + slider.value);

        // Verificamos si el slider ha llegado al valor m�ximo
      
    }

    public void SliderValue()
    {
        if (slider.value >= maxSliderValue)
        {
            Debug.Log("�Slider lleno! Destruyendo el objeto...");
            DestroyObject();
        }
    }

    // M�todo para destruir el objeto cuando el slider est� lleno
    private void DestroyObject()
    {
        if (!objectDestroyed)
        {
            Debug.Log("Destruyendo el objeto: " + objectToDestroy.name);
            Destroy(objectToDestroy); // Destruimos el objeto
            objectDestroyed = true; // Marcamos que el objeto fue destruido
            slider.gameObject.SetActive(false); // Desactivamos el slider
            Debug.Log("El objeto ha sido destruido.");
        }
        else
        {
            Debug.Log("El objeto ya fue destruido previamente.");
        }
    }
}
