using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LLAVE : MonoBehaviour
{
    public GameObject objetollave;
    public GameObject colliderPuerta;
    public GameObject panel;
    public bool pausa = false;
   

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //ColliderPuerta.gameObject.SetActive(true);
            Destroy(objetollave);
            Destroy(colliderPuerta);
           /* if (Pausa == false)
            {
                ObjetoMenuPauda.SetActive(true);
                Pausa = true;

                Time.timeScale = 0;  //Pausa el juego
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;//Hace que tu cursor no desaparesca 
            }
            else if (Pausa == true)
            {
                Resumir();
            }*/

        }
        
        if (panel != null)
        {
            bool isActive = panel.activeSelf;
            panel.SetActive(!isActive);
        }
        if (pausa == false)
        {
            panel.SetActive(true);
            pausa = true;

            Time.timeScale = 0;  //Pausa el juego
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;//Hace que tu cursor no desaparesca 
        }
        else if (pausa == true)
        {
            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                Resumir();
            }
        }

    }
    public void Resumir()
    {
       
            panel.SetActive(false);
            pausa = false;

            Time.timeScale = 1;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.None;
        
            
        

    }
}
