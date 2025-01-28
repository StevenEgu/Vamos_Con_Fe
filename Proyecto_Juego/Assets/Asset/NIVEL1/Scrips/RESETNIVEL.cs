using UnityEngine;
using TMPro;  // Para usar TextMeshPro
using UnityEngine.UI;  // Para acceder al UI de Unity
using UnityEngine.SceneManagement;  // Para cargar nuevas escenas

public class RESETNIVEL : MonoBehaviour
{
    public GameObject panel;  // El panel que se va a mostrar
    public TextMeshProUGUI texto;  // El texto que aparecer� en el panel (usando TextMeshPro)
    public Button botonReiniciar;  // El bot�n para reiniciar el nivel
    public Button botonCerrar;  // El bot�n para cerrar el juego

    private void Start()
    {
        // Asegurarnos de que el panel est� desactivado al inicio
        panel.SetActive(false);

        // Configurar los eventos de los botones
        botonReiniciar.onClick.AddListener(ReiniciarNivel);
        botonCerrar.onClick.AddListener(CerrarJuego);
    }

    // Detectamos la colisi�n con el jugador
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player")) // Aseg�rate de que el objeto tiene la etiqueta "Player"
        {
            ActivarPanelConTexto();
        }
    }

    // Activar el panel y mostrar el texto
    private void ActivarPanelConTexto()
    {
        // Detenemos el tiempo (todo se detiene, excepto el UI)
        Time.timeScale = 0f;

        // Activamos el panel
        panel.SetActive(true);

        // Modificamos el texto del panel
        texto.text = "Saliste de casa �Te gustaria seguir explorando o ya has terminado?";
    }

    // Funci�n que reinicia el nivel actual
    private void ReiniciarNivel()
    {
        // Restauramos el tiempo
        Time.timeScale = 1f;

        // Reiniciamos la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Carga la escena actual
    }

    // Funci�n que cierra el juego
    private void CerrarJuego()
    {
        // Restauramos el tiempo
        Time.timeScale = 1f;

        // Cerrar el juego (esto solo funcionar� en una compilaci�n, no en el editor)
        Application.Quit();

        // Si estamos en el editor, detener la ejecuci�n
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
