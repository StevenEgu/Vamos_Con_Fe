using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;  // Instancia para que sea un Singleton

    private void Awake()
    {
        // Aseg�rate de que solo haya una instancia de GameManager
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

    // Aqu� puedes a�adir m�todos para almacenar y recuperar datos entre escenas, como la posici�n del jugador
    public Vector3 playerPosition;
}
