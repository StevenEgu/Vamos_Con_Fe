using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class REGRASODENIVEL : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Puedes inicializar cualquier cosa aquí si es necesario
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
        // Aquí restamos 1 al índice del nivel actual para cambiar a la escena anterior
        SceneManager.LoadScene(nivelActual - 1);
    }

    // Este método ya no es necesario si estás usando la tecla 'E' para cambiar el nivel, 
    // pero si lo deseas mantenerlo por alguna razón, puedes dejarlo.
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
