using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterNavController : MonoBehaviour
{
    public Camera camera;
    public GameObject target;
    public Animator animator;

    private NavMeshAgent _navMeshAgent;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        _navMeshAgent.SetDestination(target.transform.position);
        if(TargetReached() == true)
        {
            Debug.Log("NPC arrivato al suo posto");
            animator.SetBool("isArrived", true);
        }
    }

    private bool TargetReached()
    {
        if(!_navMeshAgent.pathPending)
            if(_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
                if(!_navMeshAgent.hasPath || _navMeshAgent.velocity.sqrMagnitude <= 0f)
                    return true;
        return false;
    }
}
