using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LLAVE : MonoBehaviour
{
    public GameObject Objetollave;
    public GameObject ColliderPuerta;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            ColliderPuerta.gameObject.SetActive(true);
            Destroy(Objetollave); 
            Destroy(ColliderPuerta);
           
        }
    }
}
