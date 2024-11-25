using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuDecision : MonoBehaviour

{
    [SerializeField] private GameObject menuDecision;


    public void Afrmativo(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }

    public void Negativo()
    {
        menuDecision.SetActive(false);
    }
}
