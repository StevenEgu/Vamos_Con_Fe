using UnityEngine;
using UnityEngine.SceneManagement; // Para cargar el men� principal

public class SALIRDELJUEGO : MonoBehaviour
{
    [SerializeField] private GameObject panelConfirmacion; // Panel de confirmaci�n

    // Mostrar el panel de confirmaci�n
    public void MostrarPanelConfirmacion()
    {
        panelConfirmacion.SetActive(true); // Activa el panel de confirmaci�n
        Time.timeScale = 0f; // Pausa el juego (opcional, si el juego tiene movimiento)
    }

    // Acci�n para cuando el jugador confirma salir
    public void Salir()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit(); // Cierra el juego
    }

    // Acci�n para cuando el jugador decide no salir
    public void Cancelar()
    {
        panelConfirmacion.SetActive(false); // Oculta el panel de confirmaci�n
        Time.timeScale = 1f; // Reanuda el juego (si estaba pausado)
    }

    // Volver al men� principal
    public void RegresarAlMenuPrincipal()
    {
        Time.timeScale = 1f; // Aseg�rate de que el tiempo est� en marcha
        SceneManager.LoadScene("MenuPrincipal"); // Carga la escena del men� principal
    }
}
