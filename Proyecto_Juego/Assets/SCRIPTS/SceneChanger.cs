using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para manejar las escenas

public class SceneChanger : MonoBehaviour
{
    // Método que será llamado al hacer clic en el botón
    public void ChangeScene(string sceneName)
    {
        // Carga la escena especificada por su nombre
        SceneManager.LoadScene(sceneName);
    }
}
