using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionDeVictoria : MonoBehaviour
{
    public GameObject panelVictoria; // El panel con el mensaje "HAS GANADO"
    public string escenaFinal = "EscenaFinal"; // El nombre de la escena final a la que se cambiar�

    // Llamar a este m�todo cuando se complete la victoria
    public void MostrarVictoria()
    {
        panelVictoria.SetActive(true); // Activar el panel con el mensaje
        Invoke("CambiarEscena", 2f); // Cambiar a la escena final despu�s de 2 segundos
    }

    // Cambiar a la escena final
    void CambiarEscena()
    {
        SceneManager.LoadScene(escenaFinal); // Cambiar de escena
    }
}
