using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AVISO : MonoBehaviour
{
    [SerializeField] private GameObject anuncio;
    private bool isPlayerRange;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isPlayerRange = true;
            anuncio.SetActive(true);
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isPlayerRange= false;
            anuncio.SetActive(false);
        }
    }
}
