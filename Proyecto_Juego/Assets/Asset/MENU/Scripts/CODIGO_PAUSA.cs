using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CODIGO_PAUSA : MonoBehaviour
{
    public GameObject ObjetoMenuPauda;
    public bool Pausa = false;

    // Start is called before the first frame update
    void Start()
    {
        // Aseg�rate de que el cursor est� visible desde el inicio
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None; // Asegura que el cursor no se bloquee
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Pausa == false)
            {
                ObjetoMenuPauda.SetActive(true);
                Pausa = true;

                Time.timeScale = 0;  // Pausa el juego
                Cursor.visible = true; // Aseg�rate de que el cursor sea visible
                Cursor.lockState = CursorLockMode.None; // Aseg�rate de que el cursor no se bloquee
            }
            else if (Pausa == true)
            {
                Resumir();
            }
        }
    }

    public void Resumir()
    {
        ObjetoMenuPauda.SetActive(false);
        Pausa = false;

        Time.timeScale = 1; // Reanuda el juego
        Cursor.visible = true; // Asegura que el cursor sea visible cuando se reanuda el juego
        Cursor.lockState = CursorLockMode.None; // Asegura que el cursor no se bloquee
    }

    public void IrAlMenu(string NombreMenu)
    {
        SceneManager.LoadScene(NombreMenu);
    }

    public void Ajuste()
    {
        // Aqu� puedes agregar ajustes de sonido o gr�ficos si es necesario
    }
}
