using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverFlecha : MonoBehaviour
{
    public float velocidad = 2f;
    public float tiempoVida = 5f;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destruir", tiempoVida);

        rb = GetComponent<Rigidbody>();

        if(rb != null)
        {
            rb.velocity = (transform.forward + 0.05f* transform.up) * velocidad;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(transform.forward * velocidad * Time.deltaTime, Space.World);
    }

    void Destruir()
    {
        Destroy(gameObject);
    }
}
