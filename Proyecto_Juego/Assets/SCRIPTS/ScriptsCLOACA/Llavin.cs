using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llavin : MonoBehaviour
{
    public GameObject Objetollave;
    public GameObject ColliderPuerta;


    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            ColliderPuerta.gameObject.SetActive(true);
            Destroy(Objetollave);
        }
    }
}
