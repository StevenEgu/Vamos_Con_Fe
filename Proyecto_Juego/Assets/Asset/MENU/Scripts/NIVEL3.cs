using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NIVEL3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    [ContextMenu("boton cambiar nivel")]

    public void CambiarNivel()
    {
        int nivelActual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(13);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "NIVEL3")
        {
            Debug.Log("Tocando algo");
            int nivelActual = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(10);
        }
    }
}
