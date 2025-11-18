using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorConAnimacion : MonoBehaviour
{

    private Animator animator;
    private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        BuscarComponentes();
    }

    // Update is called once per frame
    void Update()
    {
        InputJugador(); 
    }

    void BuscarComponentes()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    void InputJugador()
    {
        float InputX = Input.GetAxis("Horizontal");
        float InputZ = Input.GetAxis("Vertical");

        animator.SetFloat("InputX",InputX);
        animator.SetFloat("InputZ", InputZ);
    }

    private void OnAnimatorMove()
    {
        Vector3 movimientoAnimator = animator.rootPosition - transform.position;
        Vector3 movimientoTotal = movimientoAnimator;
        characterController.Move(movimientoTotal);

    }
}
