using UnityEngine;
using UnityEngine.SceneManagement; // Para cargar el menú principal

public class SALIRDELJUEGO : MonoBehaviour
{
    [SerializeField] private GameObject panelConfirmacion; // Panel de confirmación

    // Mostrar el panel de confirmación
    public void MostrarPanelConfirmacion()
    {
        panelConfirmacion.SetActive(true); // Activa el panel de confirmación
        Time.timeScale = 0f; // Pausa el juego (opcional, si el juego tiene movimiento)
    }

    // Acción para cuando el jugador confirma salir
    public void Salir()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit(); // Cierra el juego
    }

    // Acción para cuando el jugador decide no salir
    public void Cancelar()
    {
        panelConfirmacion.SetActive(false); // Oculta el panel de confirmación
        Time.timeScale = 1f; // Reanuda el juego (si estaba pausado)
    }

    // Volver al menú principal
    public void RegresarAlMenuPrincipal()
    {
        Time.timeScale = 1f; // Asegúrate de que el tiempo esté en marcha
        SceneManager.LoadScene("MenuPrincipal"); // Carga la escena del menú principal
    }
}
