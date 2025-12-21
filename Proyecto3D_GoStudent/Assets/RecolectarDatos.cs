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

    // Start is called before the first frame update
    void Start()
    {
        string fecha = DateTime.Now.ToString("yyyyMMdd_HHmmss");
        rutaCompleta = Path.Combine(rutaArchivos, $"Datos{fecha}.csv");
        using (StreamWriter writer = new StreamWriter(rutaCompleta, false))
        {
            writer.WriteLine("tiempo,posX,posY,posZ,rotX,rotY,rotZ,rotW,inputX,inputZ"); 

        }
        ultimaPos = transform.position;
        ultimaRot = transform.rotation;
        ultimoHorizontal = 0;
        ultimoVertical = 0; 

    }

    // Update is called once per frame
    void Update()
    {
        float time = Time.time;
        Vector3 pos = transform.position;
        Quaternion rot = transform.rotation;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        using (StreamWriter writer = new StreamWriter(rutaCompleta, true))
        {
            //Guardamos el tiempo de este frame
            writer.Write(time.ToString("F4") + ",");

            //Guardamos la posición de este frame
            if (pos != ultimaPos)
            {
                writer.Write($"{pos.x},{pos.y},{pos.z},");
            }
            else
            {
                writer.Write(",,,");
            }

            //Guardamos la rotación en este frame
            if (rot != ultimaRot)
            {
                writer.Write($"{rot.x},{rot.y},{rot.z},{rot.w},");
            }
            else
            {
                writer.Write(",,,,");
            }

            //Guardamos el input horizontal
            if (horizontal != ultimoHorizontal)
            {
                writer.Write($"{horizontal},");

            }
            else
            {
                writer.Write(",");
            }

            //Guardamos el input vertical
            if (vertical != ultimoVertical)
            {
                writer.Write($"{vertical},");
            }
            else
            {
                writer.Write(",");
            }

            writer.WriteLine();

        }

        ultimaPos = pos;
        ultimaRot = rot;
        vertical = ultimoVertical;
        horizontal = ultimoHorizontal;

    }
}
