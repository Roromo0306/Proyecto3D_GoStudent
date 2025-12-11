using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemiga : MonoBehaviour
{
    public bool Morir = false;

    private ObjetivoArquera objetivoArquera;
    private DisparoArqueraEnemiga disparoArqueraEnemiga;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        BuscarComponentes();
    }

    // Update is called once per frame
    void Update()
    {
        if(Morir)
        {
            DesactivarCodigos();
            Morir = false;
        }
    }
    void BuscarComponentes()
    {

    }
    void DesactivarCodigos()
    {
        //desactivar objetivoarquera, disparo y animator
    }
}
