using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoArqueraEnemiga : MonoBehaviour
{
    public GameObject bala;
    public Transform puntoDisparo;
    public float cooldown = 1f;

    private ObjetivoArquera objetivoArquera;
    // Start is called before the first frame update
    void Start()
    {
        BuscarComponentes();
        StartCoroutine(Disparo());
    }

   

    void BuscarComponentes()
    {
        objetivoArquera = GetComponent<ObjetivoArquera>();
    }

    IEnumerator Disparo()
    {
        while (true)
        {
            if (objetivoArquera.puedeDisparar == true)
            {
                Instantiate(bala, puntoDisparo.position, puntoDisparo.rotation);
                
            }
            yield return new WaitForSeconds(cooldown);
        }

    }
}
