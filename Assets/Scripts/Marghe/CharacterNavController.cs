using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterNavController : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _target;
    [SerializeField] private Animator _animator;

    private NavMeshAgent _navMeshAgent;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _navMeshAgent.SetDestination(_target.transform.position);
            _animator.SetBool("isWalking", true);
        }

        if(TargetReached())
        {
            _animator.SetBool("isWalking", false);
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
