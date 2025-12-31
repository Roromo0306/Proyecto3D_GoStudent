using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;

public class RecolectarDatos : MonoBehaviour
{
    public string rutaArchivos = "C:\\Users\\powny\\Downloads";
    public GameObject panel;

    private Slider[] sliders;
    private string rutaCompleta = "";

    private Vector3 ultimaPos;
    private Quaternion ultimaRot;
    private float ultimoHorizontal;
    private float ultimoVertical;

    void Start()
    {
        // Obtenemos los sliders del panel
        sliders = panel.GetComponentsInChildren<Slider>();

        string fecha = DateTime.Now.ToString("yyyyMMdd_HHmmss");
        rutaCompleta = Path.Combine(rutaArchivos, $"Datos{fecha}.csv");

        using (StreamWriter writer = new StreamWriter(rutaCompleta, false))
        {
            writer.Write("tiempo,posX,posY,posZ,rotX,rotY,rotZ,rotW,inputX,inputZ");

            // Columnas para los sliders
            foreach (Slider s in sliders)
            {
                writer.Write("," + s.name);
            }

            writer.WriteLine();
        }

        ultimaPos = transform.position;
        ultimaRot = transform.rotation;
        ultimoHorizontal = 0;
        ultimoVertical = 0;
    }

    void Update()
    {
        float time = Time.time;
        Vector3 pos = transform.position;
        Quaternion rot = transform.rotation;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        using (StreamWriter writer = new StreamWriter(rutaCompleta, true))
        {
            writer.Write(time.ToString("F4") + ",");

            if (pos != ultimaPos)
                writer.Write($"{pos.x},{pos.y},{pos.z},");
            else
                writer.Write(",,,");

            if (rot != ultimaRot)
                writer.Write($"{rot.x},{rot.y},{rot.z},{rot.w},");
            else
                writer.Write(",,,,");

            if (horizontal != ultimoHorizontal)
                writer.Write($"{horizontal},");
            else
                writer.Write(",");

            if (vertical != ultimoVertical)
                writer.Write($"{vertical},");
            else
                writer.Write(",");

           
            foreach (Slider s in sliders)
            {
                writer.Write($"{s.value},");
            }

            writer.WriteLine();
        }

        ultimaPos = pos;
        ultimaRot = rot;
        ultimoHorizontal = horizontal;
        ultimoVertical = vertical;
    }
}
