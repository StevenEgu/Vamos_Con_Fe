using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class puerta : MonoBehaviour
{
     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            int nivelActual = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(nivelActual + 3);
        }
    }
}
