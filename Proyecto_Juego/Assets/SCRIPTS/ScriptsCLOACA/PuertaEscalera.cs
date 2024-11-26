using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuertaEscalera : MonoBehaviour
{

    public string nombre;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            SceneManager.LoadScene(nombre);
        }
    }
}
