using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class REGRASODENIVEL : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Puedes inicializar cualquier cosa aqu� si es necesario
    }

    // Update is called once per frame
    void Update()
    {
        // Verificar si se presiona la tecla 'E'
        if (Input.GetKeyDown(KeyCode.E))
        {
            CambiarNivel();
        }
    }

    [ContextMenu("boton cambiar nivel")]
    public void CambiarNivel()
    {
        int nivelActual = SceneManager.GetActiveScene().buildIndex;
        // Aqu� restamos 1 al �ndice del nivel actual para cambiar a la escena anterior
        SceneManager.LoadScene(nivelActual - 1);
    }

    // Este m�todo ya no es necesario si est�s usando la tecla 'E' para cambiar el nivel, 
    // pero si lo deseas mantenerlo por alguna raz�n, puedes dejarlo.
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Regreso")
        {
            Debug.Log("Tocando algo");
            int nivelActual = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(nivelActual + -1);
        }
    }
}
