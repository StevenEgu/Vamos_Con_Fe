using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;

public class ObjetoDaño : MonoBehaviour
{
    public int daño;

    //public event EventHandler MuerteJugador
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent(out VidaJugador vidaJugador))
        {
            vidaJugador.TomarDaño(daño);
        }
    }
}
