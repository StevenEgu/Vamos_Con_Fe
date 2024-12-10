using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CAMBIODENIVEL : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Detectar si el jugador presiona la tecla 'E' para cambiar de nivel
        if (Input.GetKeyDown(KeyCode.E))
        {
            CambiarNivel();
        }
    }

    [ContextMenu("boton cambiar nivel")]
    public void CambiarNivel()
    {
        int nivelActual = SceneManager.GetActiveScene().buildIndex;
        // Cargar la siguiente escena (nivel + 1)
        SceneManager.LoadScene(nivelActual + 1);
    }

    // Detectar colisión con un objeto que tenga el tag "Cambio"
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Cambio"))
        {
            Debug.Log("Tocando algo");
            // Cambiar de nivel si el jugador colisiona con el objeto que tiene el tag "Cambio"
            int nivelActual = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(nivelActual + 1);
        }
    }
}
