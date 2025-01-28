using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABRIRPANELK : MonoBehaviour
{
    public GameObject Panel;
    public GameObject coliderSombra;
    public void OpenPanel()
    {
        if (Panel != null)
        {
            bool isActive = Panel.activeSelf;
            Panel.SetActive(!isActive);
            Destroy(coliderSombra);
        }
    }
    
}
