using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MAINPANEL : MonoBehaviour
{
    [Header("OIPTIONS")]
    public SliderJoint2D VolumenFX;
    public SliderJoint2D VolumenMaster;
    public Toggle mute;
    [Header("Panels")]
    public GameObject mainPanel;
    public GameObject optionsPanel;
    public GameObject levelselectPanel;

    public void OpenPanel(GameObject panel)
    {
        mainPanel.SetActive(false);
        optionsPanel.SetActive(false);
        levelselectPanel.SetActive(false);

        panel.SetActive(true);
    }
}
