using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public static Main Instance;      // Instancia est�tica de la clase Main
    public int switchCount;           // N�mero total de switches que deben activarse
    public GameObject winText;       // Texto que se muestra al ganar
    private int onCount = 0;          // Contador de switches activados

    private void Awake()
    {
        Instance = this;  // Establecemos la instancia est�tica de la clase Main
    }

    // M�todo que se llama para incrementar el contador de switches activados
    public void SwitchChange(int points)
    {
        onCount += points;  // Aumentamos el contador de switches

        // Si el contador de switches activados alcanza el n�mero total necesario para ganar
        if (onCount == switchCount)
        {
            winText.SetActive(true);  // Activamos el texto de victoria
        }
    }

    private void Update()
    {
        // Si se presiona la tecla R, recargamos la escena actual
       /* if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Recargamos la escena
        */
    }
}