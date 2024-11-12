using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class llave : MonoBehaviour
{
    public GameObject Objetollave;
    public GameObject ColliderPuerta;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ColliderPuerta.gameObject.SetActive(false);
            Destroy(Objetollave);
        }
    }
}
