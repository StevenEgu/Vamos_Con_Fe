using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioHabitacion : MonoBehaviour
{
    public Vector3 playerSpawnPosition;  // Nueva posición donde el jugador aparecerá
    private bool dentroDelTrigger = false; // Verifica si el jugador está dentro del área del trigger

    public string sceneName; // Nombre de la escena a cargar

    // Método que se llama cuando el jugador presiona "E" dentro del trigger
    void Update()
    {
        // Si el jugador está dentro del trigger y presiona la tecla 'E', cambiar de nivel
        if (dentroDelTrigger && Input.GetKeyDown(KeyCode.E))
        {
            ChangeScene(sceneName);  // Cambiar a la escena especificada
        }
    }

    // Método para cambiar de escena
    public void ChangeScene(string sceneName)
    {
        // Guardar la posición actual del jugador antes de cambiar de escena
        if (GameManager.Instance != null)
        {
            GameManager.Instance.playerPosition = transform.position;
        }

        // Cargar la nueva escena
        SceneManager.LoadScene(sceneName);
    }

    // Al cargar una nueva escena, mover al jugador a la nueva posición
    private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            player.transform.position = playerSpawnPosition;  // Mueve al jugador a la nueva posición
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;  // Escuchar cuando una escena se ha cargado
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;  // Desescuchar cuando se desactive este script
    }

    // Detectar cuando el jugador entra en el trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dentroDelTrigger = true;  // El jugador está dentro del trigger
        }
    }

    // Detectar cuando el jugador sale del trigger
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dentroDelTrigger = false;  // El jugador sale del trigger
        }
    }
}
