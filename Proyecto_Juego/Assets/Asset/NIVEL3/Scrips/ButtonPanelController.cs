using UnityEngine;
using UnityEngine.UI;

public class ButtonPanelController : MonoBehaviour
{
    // Referencias a los botones
    public Button[] buttons;  // Los 4 botones (puedes asignarlos en el inspector)
    public Button openButton; // El botón "Open"

    // Referencia al GameObject que se va a destruir
    public GameObject objectToDestroy;

    // La secuencia de botones que debe presionar el jugador (índices de los botones)
    public int[] correctSequence;

    // Referencias a las imágenes que simulan las luces (GameObjects)
    public GameObject[] lightGameObjects; // Las imágenes (GameObjects) que simulan las luces

    private int currentStep = 0; // Controla el paso actual en la secuencia
    private bool objectDestroyed = false; // Bandera para saber si el objeto ya fue destruido

    void Start()
    {
        // Asignamos las acciones a los botones
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // Necesitamos una copia local para el evento
            buttons[i].onClick.AddListener(() => OnButtonPressed(index));
        }

        openButton.onClick.AddListener(OnOpenPressed); // Acción del botón "Open"

        openButton.interactable = false; // Deshabilitamos el botón "Open" al principio
        Debug.Log("Iniciando el juego. El botón Open está deshabilitado.");

        // Aseguramos que las imágenes (luces) estén apagadas al principio
        SetLightGameObjects(false);
    }

    // Método que se llama cuando se presiona un botón
    void OnButtonPressed(int buttonIndex)
    {
        if (objectDestroyed)
        {
            // Si el objeto fue destruido, no hacemos nada con los botones
            Debug.Log("El objeto ya fue destruido, los botones están deshabilitados.");
            return;
        }

        Debug.Log("Se presionó el botón con el índice: " + buttonIndex);

        // Verificamos si el índice presionado corresponde al siguiente en la secuencia
        if (buttonIndex == correctSequence[currentStep])
        {
            Debug.Log("Presionaste el botón correcto: " + buttonIndex);
            currentStep++;

            // Encender la imagen correspondiente al botón presionado
            SetLightGameObject(buttonIndex, true);

            // Si el jugador ha presionado todos los botones en orden, habilitamos el botón Open
            if (currentStep == correctSequence.Length)
            {
                Debug.Log("¡Secuencia correcta completada! El botón Open ahora está habilitado.");
                openButton.interactable = true; // Habilitamos el botón Open
            }
        }
        else
        {
            // Si el orden es incorrecto, reiniciamos la secuencia y apagamos las imágenes
            currentStep = 0;
            openButton.interactable = false; // Deshabilitamos el botón Open nuevamente
            Debug.Log("Error: El orden fue incorrecto. Reiniciando la secuencia.");
            SetLightGameObjects(false); // Apagamos todas las imágenes
        }
    }

    // Método que se llama cuando se presiona el botón "Open"
    void OnOpenPressed()
    {
        if (objectDestroyed)
        {
            Debug.Log("El objeto ya fue destruido.");
            return;
        }

        Debug.Log("Botón Open presionado. Destruyendo el objeto...");

        // Destruimos el objeto al presionar "Open"
        Destroy(objectToDestroy);

        // Deshabilitamos los botones después de destruir el objeto
        DisableButtons();

        objectDestroyed = true; // Marcamos que el objeto ha sido destruido
    }

    // Método para deshabilitar la interactividad de los botones
    void DisableButtons()
    {
        foreach (Button btn in buttons)
        {
            btn.interactable = false; // Deshabilitamos cada botón
        }

        openButton.interactable = false; // Deshabilitamos el botón "Open" también
        Debug.Log("Los botones han sido deshabilitados.");
    }

    // Método para encender o apagar una imagen específica (de acuerdo al botón presionado)
    void SetLightGameObject(int lightIndex, bool state)
    {
        if (lightGameObjects != null && lightIndex >= 0 && lightIndex < lightGameObjects.Length)
        {
            lightGameObjects[lightIndex].SetActive(state); // Activamos o desactivamos el GameObject
        }
    }

    // Método para apagar todas las imágenes (luces)
    void SetLightGameObjects(bool state)
    {
        foreach (GameObject light in lightGameObjects)
        {
            light.SetActive(state); // Activamos o desactivamos todos los GameObjects
        }
    }
}
