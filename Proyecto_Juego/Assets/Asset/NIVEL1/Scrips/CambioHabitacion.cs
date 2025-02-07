using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioHabitacion : MonoBehaviour
{
    public Vector3 playerSpawnPosition;  // Nueva posici�n donde el jugador aparecer�
    public Vector3 inicialPosition;
    private bool dentroDelTrigger = false; // Verifica si el jugador est� dentro del �rea del trigger
    public GuardadodeEscenas guardadodeEscenas;

    public string sceneName; // Nombre de la escena a cargar

    // M�todo que se llama cuando el jugador presiona "E" dentro del trigger
    void Update()
    {
        // Si el jugador est� dentro del trigger y presiona la tecla 'E', cambiar de nivel
        if (dentroDelTrigger && Input.GetKeyDown(KeyCode.E))
        {
            
            ChangeScene(sceneName);  // Cambiar a la escena especificada
        }
    }
    void Start()
    {
        Scene escena =SceneManager.GetActiveScene();
        guardadodeEscenas.escenaActual = SceneManager.GetActiveScene().buildIndex;


    }

    // M�todo para cambiar de escena
    public void ChangeScene(string sceneName)
    {
       
        GameObject player = GameObject.FindWithTag("Player");
        //guardadodeEscenas.escenaActual = SceneManager.GetActiveScene().buildIndex;
        // Guardar la posici�n actual del jugador antes de cambiar de escena
        if (GameManager.Instance != null)
        {
            GameManager.Instance.playerPosition = transform.position;
            
        }

       

        // Cargar la nueva escena
        SceneManager.LoadScene(sceneName);
    }

    // Al cargar una nueva escena, mover al jugador a la nueva posici�n
    private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {

        GameObject player = GameObject.FindWithTag("Player");

        if (guardadodeEscenas.escenaActual == 5)
        {
            player.transform.position = playerSpawnPosition;
        }
        else
        {
            player.transform.position = inicialPosition;
        }


       
        
         // Mueve al jugador a la nueva posici�n

           

       /* if (scenaJardin==SceneManager.GetActiveScene())
        {

            player.transform.position = playerSpawnPosition;

        }*/
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
            dentroDelTrigger = true;  // El jugador est� dentro del trigger
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
