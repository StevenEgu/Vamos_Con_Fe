using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioHabitacion : MonoBehaviour
{
    public Vector3 posicionEspecifica;  // Nueva posici�n en la que queremos que aparezca el jugador

    public void ChangeScene(string sceneName)
    {
        // Guardar la posici�n actual del jugador antes de cambiar de escena
        if (GameManager.Instance != null)
        {
            GameManager.Instance.playerPosition = transform.position;
        }

        // Cargar la nueva escena
        SceneManager.LoadScene(sceneName);

        // Una vez que la escena se cargue, podemos mover al jugador a la nueva posici�n
        // Esto se puede hacer en el m�todo OnSceneLoaded
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Esto se llama cuando una escena se ha cargado
        if (GameManager.Instance != null)
        {
            // Asegurarse de que el jugador se mueva a la posici�n correcta
            Transform playerTransform = GameObject.FindWithTag("Player").transform;
            if (playerTransform != null)
            {
                playerTransform.position = GameManager.Instance.playerPosition != Vector3.zero ? GameManager.Instance.playerPosition : posicionEspecifica;
            }
        }

        // Desuscribir para evitar llamadas repetidas
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
