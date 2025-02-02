using UnityEngine;

public class PausaJuego : MonoBehaviour
{
    public GameObject panelPausa;  // Referencia al panel de pausa
    private bool juegoPausado = false;  // Estado para saber si el juego está pausado

    void Update()
    {
        // Comprobar si presionas la tecla "P" para activar el panel
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (juegoPausado)
            {
                ReanudarJuego();  // Si está pausado, reanudar el juego
            }
            else
            {
                PausarJuego();  // Si no está pausado, pausar el juego
            }
        }
    }

    // Método para pausar el juego
    public void PausarJuego()
    {
        panelPausa.SetActive(true);  // Activa el panel de pausa
        Time.timeScale = 0f;  // Pausa el tiempo en el juego
        juegoPausado = true;  // Marca el juego como pausado
    }

    // Método para reanudar el juego
    public void ReanudarJuego()
    {
        panelPausa.SetActive(false);  // Desactiva el panel de pausa
        Time.timeScale = 1f;  // Reanuda el tiempo en el juego
        juegoPausado = false;  // Marca el juego como reanudado
    }

    // Método para salir del panel de pausa (por ejemplo, desde un botón en el panel)
    public void SalirDelPanel()
    {
        ReanudarJuego();  // Reanudar el juego cuando se salga del panel
    }
}
