using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ObjetivoEnemigo : MonoBehaviour
{
    public Transform objetivo;

    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        BuscarComponentes();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(objetivo.position);
    }
    void BuscarComponentes()
    {
       agent = GetComponent<NavMeshAgent>();
        
        if(agent == null)
        {
            Debug.LogError("NavMeshAgent no encontrado");
        }
    }
}
