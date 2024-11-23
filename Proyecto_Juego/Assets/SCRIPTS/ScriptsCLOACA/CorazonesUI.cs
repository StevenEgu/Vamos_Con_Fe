using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CorazonesUI : MonoBehaviour
{
    public List<Image> listaCorazones;

    public GameObject corazonPrefab;

    public VidaJugador vidaJugador;

    public int indexActual;

    public Sprite corazonLleno;

    public Sprite corazonVacio;

    private void Awake()
    {
        vidaJugador.cambioVida.AddListener(CambiarCorazones);
    }

    private void CambiarCorazones(int vidaActual)
    {
        if (!listaCorazones.Any())
        {
            CrearCorazones(vidaActual);
        }
        else
        {
            CambiarVida(vidaActual);
        }
    }

    private void CrearCorazones(int vidaActual)
    {
        for (int i = 0; i < vidaActual; i++)
        {
            GameObject corazon = Instantiate(corazonPrefab, transform);
            listaCorazones.Add(corazon.GetComponent<Image>());
        }
        indexActual = vidaActual - 1;
    }

    private void CambiarVida(int vidaActual)
    {

    }
}
