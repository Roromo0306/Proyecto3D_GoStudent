using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarMenu : MonoBehaviour
{
    public GameObject panelSliders;

    private bool slidersActivos = false;
    // Start is called before the first frame update
    void Start()
    {
        panelSliders.SetActive(slidersActivos);

    }

    public void ActivarPanel()
    {
        slidersActivos = !slidersActivos;
        panelSliders.SetActive(slidersActivos);

         if(slidersActivos)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

}
