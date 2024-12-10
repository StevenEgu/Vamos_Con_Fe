using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sala : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CambiarNivel();
        }
    }

    [ContextMenu("boton cambiar nivel")]

    public void CambiarNivel()
    {
        int nivelActual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(3);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Salon")
        {
            Debug.Log("Tocando algo");
            int nivelActual = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(3);
        }
    }
}
