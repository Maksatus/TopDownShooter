using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    private enum State
    {
        Idle,
        ChaseTarget,
        ShootingTarget,
        GoingBackToStart,
    }
    
    [SerializeField] private NavMeshAgent pathfindingMovement;
    [SerializeField] private EnemyAttack enemyAttack;
    private Vector3 _roamPosition;
    private float _nextShootTime;
    private State _state;

    private void Awake()
    {
        _state = State.Idle;
    }

    private void Start()
    {
    }

    private void Update()
    {
        FindTarget();
        switch (_state)
        {
            case State.Idle:
                break;
            case State.ChaseTarget:
                pathfindingMovement.SetDestination(Player.Instance.GetPosition());
                float attackRange = 2f;
                if (Vector3.Distance(transform.position,Player.Instance.GetPosition()) < attackRange)
                {
                    pathfindingMovement.isStopped = true;
                    enemyAttack.Attack();
                }
                else
                {
                    EnemyAttack.isAtack();
                    pathfindingMovement.isStopped = false;
                }
                break;
            case State.ShootingTarget:
                break;
            case State.GoingBackToStart:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
       
    }
    

    private void FindTarget()
    {
        var targetRange = 20f;
        if (Vector3.Distance(transform.position, Player.Instance.GetPosition()) < targetRange)
        {
            // Player within target range
            _state = State.ChaseTarget;
        }
    }
}