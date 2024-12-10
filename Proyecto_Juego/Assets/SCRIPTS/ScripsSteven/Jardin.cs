using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jardin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Aquí puedes inicializar cualquier cosa si lo necesitas
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
        // Cambiar al nivel con índice 6
        SceneManager.LoadScene(6);
    }

    // Detectar colisión con un objeto que tenga el tag "Jardin"
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Jardin"))
        {
            Debug.Log("Tocando algo");
            // Cambiar al nivel con índice 6
            SceneManager.LoadScene(6);
        }
    }
}

