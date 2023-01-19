using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class HauntedFigure : MonoBehaviour
{
    private NavMeshAgent _agent;

    [SerializeField] Transform dest; 

    private void Start()
    {
        _agent= GetComponent<NavMeshAgent>();   
    }


    // Update is called once per frame
    void Update()
    {
        _agent.SetDestination(dest.position); 
    }
}
