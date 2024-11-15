using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para manejar las escenas

public class SceneChanger : MonoBehaviour
{
    // M�todo que ser� llamado al hacer clic en el bot�n
    public void ChangeScene(string sceneName)
    {
        // Carga la escena especificada por su nombre
        SceneManager.LoadScene(sceneName);
    }
}
