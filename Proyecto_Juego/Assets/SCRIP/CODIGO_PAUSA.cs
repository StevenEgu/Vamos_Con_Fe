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
           
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) 
        { 
            if(Pausa==false) 
            { 
                ObjetoMenuPauda.SetActive(true);
                Pausa = true;

                Time.timeScale = 0;  //Pausa el juego
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;//Hace que tu cursor no desaparesca 
            }
            else if(Pausa==true) 
            {
                Resumir();
            }
        }
    }
    public void Resumir()
    {
        ObjetoMenuPauda.SetActive(false); 
        Pausa = false;

        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;
    }

    public void IrAlMenu(string NombreMenu) 
    { 
        SceneManager.LoadScene(NombreMenu);
    }
}
