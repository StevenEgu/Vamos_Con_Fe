using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioHabitacion : MonoBehaviour
{
    public Vector3 playerSpawnPosition;  // Nueva posición donde el jugador aparecerá

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
}
