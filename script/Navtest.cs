using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Navtest : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    public Transform GOTO;
    public float distanceThrushold;
    public Animator animator;

    
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, GOTO.position) > distanceThrushold)
        {
            navMeshAgent.SetDestination(GOTO.position);
            animator.SetInteger("MovementState", 2);


        }
        else
        {
            animator.SetInteger("MovementState", 0);

            navMeshAgent.ResetPath();
        }
    }
}
