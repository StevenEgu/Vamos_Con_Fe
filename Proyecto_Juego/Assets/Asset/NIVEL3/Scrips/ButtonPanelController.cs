using UnityEngine;
using UnityEngine.UI;

public class ButtonPanelController : MonoBehaviour
{
    // Referencias a los botones
    public Button[] buttons;  // Los 4 botones (puedes asignarlos en el inspector)
    public Button openButton; // El bot�n "Open"

    // Referencia al GameObject que se va a destruir
    public GameObject objectToDestroy;

    // La secuencia de botones que debe presionar el jugador (�ndices de los botones)
    public int[] correctSequence;

    // Referencias a las im�genes que simulan las luces (GameObjects)
    public GameObject[] lightGameObjects; // Las im�genes (GameObjects) que simulan las luces

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

        openButton.onClick.AddListener(OnOpenPressed); // Acci�n del bot�n "Open"

        openButton.interactable = false; // Deshabilitamos el bot�n "Open" al principio
        Debug.Log("Iniciando el juego. El bot�n Open est� deshabilitado.");

        // Aseguramos que las im�genes (luces) est�n apagadas al principio
        SetLightGameObjects(false);
    }

    // M�todo que se llama cuando se presiona un bot�n
    void OnButtonPressed(int buttonIndex)
    {
        if (objectDestroyed)
        {
            // Si el objeto fue destruido, no hacemos nada con los botones
            Debug.Log("El objeto ya fue destruido, los botones est�n deshabilitados.");
            return;
        }

        Debug.Log("Se presion� el bot�n con el �ndice: " + buttonIndex);

        // Verificamos si el �ndice presionado corresponde al siguiente en la secuencia
        if (buttonIndex == correctSequence[currentStep])
        {
            Debug.Log("Presionaste el bot�n correcto: " + buttonIndex);
            currentStep++;

            // Encender la imagen correspondiente al bot�n presionado
            SetLightGameObject(buttonIndex, true);

            // Si el jugador ha presionado todos los botones en orden, habilitamos el bot�n Open
            if (currentStep == correctSequence.Length)
            {
                Debug.Log("�Secuencia correcta completada! El bot�n Open ahora est� habilitado.");
                openButton.interactable = true; // Habilitamos el bot�n Open
            }
        }
        else
        {
            // Si el orden es incorrecto, reiniciamos la secuencia y apagamos las im�genes
            currentStep = 0;
            openButton.interactable = false; // Deshabilitamos el bot�n Open nuevamente
            Debug.Log("Error: El orden fue incorrecto. Reiniciando la secuencia.");
            SetLightGameObjects(false); // Apagamos todas las im�genes
        }
    }

    // M�todo que se llama cuando se presiona el bot�n "Open"
    void OnOpenPressed()
    {
        if (objectDestroyed)
        {
            Debug.Log("El objeto ya fue destruido.");
            return;
        }

        Debug.Log("Bot�n Open presionado. Destruyendo el objeto...");

        // Destruimos el objeto al presionar "Open"
        Destroy(objectToDestroy);

        // Deshabilitamos los botones despu�s de destruir el objeto
        DisableButtons();

        objectDestroyed = true; // Marcamos que el objeto ha sido destruido
    }

    // M�todo para deshabilitar la interactividad de los botones
    void DisableButtons()
    {
        foreach (Button btn in buttons)
        {
            btn.interactable = false; // Deshabilitamos cada bot�n
        }

        openButton.interactable = false; // Deshabilitamos el bot�n "Open" tambi�n
        Debug.Log("Los botones han sido deshabilitados.");
    }

    // M�todo para encender o apagar una imagen espec�fica (de acuerdo al bot�n presionado)
    void SetLightGameObject(int lightIndex, bool state)
    {
        if (lightGameObjects != null && lightIndex >= 0 && lightIndex < lightGameObjects.Length)
        {
            lightGameObjects[lightIndex].SetActive(state); // Activamos o desactivamos el GameObject
        }
    }

    // M�todo para apagar todas las im�genes (luces)
    void SetLightGameObjects(bool state)
    {
        foreach (GameObject light in lightGameObjects)
        {
            light.SetActive(state); // Activamos o desactivamos todos los GameObjects
        }
    }
}
