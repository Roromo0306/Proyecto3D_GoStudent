using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorConAnimacion : MonoBehaviour
{
    [Header("Giro")]
    public float velocidadGiro = 100f;

    [Header("Salto")]
    public float velocidadSalto = 50f;
    public float gravedad = 10f;
    public float velocidadPegarseSuelo = 2f;
    private float velocidadVertical = 0f;

    [Header("Control Aereo")]
    public float velocidadEnAire = 3f;


    public bool enSuelo = false;
    private bool saltando = false;
    private Animator animator;
    private CharacterController characterController;
    private float InputX, InputZ;
    private float InputGiro;


    // Start is called before the first frame update
    void Start()
    {
        BuscarComponentes();
    }

    // Update is called once per frame
    void Update()
    {
        InputJugador();
        UpdateGiro();
        UpdateSalto();
        AplicarGravedad();
        MovimientoAereo();
        Baile();
    }

    void BuscarComponentes()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    void InputJugador()
    {
         InputX = Input.GetAxis("Horizontal");
         InputZ = Input.GetAxis("Vertical");
         InputGiro = Input.GetAxis("Mouse X");

        animator.SetFloat("InputX",InputX);
        animator.SetFloat("InputZ", InputZ);
    }

    private void OnAnimatorMove()
    {
        Vector3 movimientoAnimator = animator.rootPosition - transform.position;
        Vector3 movimientoTotal = movimientoAnimator + velocidadVertical * Vector3.up * Time.deltaTime;
        characterController.Move(movimientoTotal);

    }

    void UpdateGiro()
    {
        transform.Rotate(0, InputGiro * velocidadGiro * Time.deltaTime,0);
    }

    void UpdateSalto()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("Jumping", true);
           
            
            Debug.LogWarning("Espacio pulsado");
        }

        if (saltando)
        {
            if(enSuelo)
            {
                animator.SetBool("Jumping", false);
                Debug.LogWarning("SaltoFinalizado");
                saltando =false;
            }

        }


    }

    void Baile()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            animator.SetBool("Dancing", true);
        }

        
        if (Mathf.Abs(InputX) > 0.1f || Mathf.Abs(InputZ) > 0.1f)
        {
            if (animator.GetBool("Dancing"))
                animator.SetBool("Dancing", false);
        }
    }
    void AplicarVelocidadSalto()
    {
        velocidadVertical = velocidadSalto;
    }

    void AplicarGravedad()
    {
        enSuelo = characterController.isGrounded;
        

        if (!enSuelo)
        {
            velocidadVertical -= gravedad * Time.deltaTime;
        }
        else
        {
            velocidadVertical = -velocidadPegarseSuelo;
        }
    }

    void SaltandoTrue()
    {
        saltando = true;
    }

    void MovimientoAereo()
    {
        if(!enSuelo)
        {
            Vector3 inputTotal = transform.right * InputX + transform.forward * InputZ;
            inputTotal.Normalize();
            characterController.Move(inputTotal * velocidadEnAire * Time.deltaTime);
        }    
    }
}
