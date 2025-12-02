using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class ObjetivoArquera : MonoBehaviour
{
    public Transform objetivo;
    public float radioPerseguir = 10f;
    public float radioHuir = 5f;

    private NavMeshAgent agent;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        BuscarComponentes();
    }

    // Update is called once per frame
    void Update()
    {
        if(objetivo == null)
        {
            Debug.LogError("Objetivo no asignado");
            return;
        }
        float radio = Vector3.Distance(transform.position, objetivo.position);
        Vector3 orientacion = (objetivo.position - transform.position).normalized;

        transform.forward = orientacion;

        if (radio >= radioPerseguir)
        {
            agent.SetDestination(objetivo.position);
            animator.SetBool("Persiguiendo", true);
            animator.SetBool("Huyendo", false);
        }
        else if(radio >= radioHuir && radio < radioPerseguir)
        {
            agent.SetDestination(transform.position);
            animator.SetBool("Persiguiendo", false);
            animator.SetBool("Huyendo", false);
        }
        else
        {
            agent.SetDestination(transform.position - orientacion);
            animator.SetBool("Persiguiendo", false);
            animator.SetBool("Huyendo", true);
        }

    }
    void BuscarComponentes()
    {
        agent = GetComponent<NavMeshAgent>();

        if (agent == null)
        {
            Debug.LogError("NavMeshAgent no encontrado");
        }

        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator no encontrado");
        }
    }
}
