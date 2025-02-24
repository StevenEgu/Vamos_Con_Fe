using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;  // Instancia para que sea un Singleton

    private void Awake()
    {
        // Asegúrate de que solo haya una instancia de GameManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // No destruye este GameObject al cambiar de escena
        }
        else
        {
            Destroy(gameObject);  // Si ya existe, destruye esta nueva instancia
        }
    }

    // Aquí puedes añadir métodos para almacenar y recuperar datos entre escenas, como la posición del jugador
    public Vector3 playerPosition;
}
