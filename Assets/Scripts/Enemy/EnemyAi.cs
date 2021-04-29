using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private NavMeshAgent pathfindingMovement;
    [SerializeField] private EnemyAttack enemyAttack;
    [SerializeField] private EnemyInfo enemyInfo;

    private float _nextShootTimer;
    private enum State
    {
        Idle,
        ChaseTarget,
        ShootingTarget,
        GoingBackToStart,
    }

    private Vector3 _roamPosition;
    private float _nextShootTime;
    private State _state;

    private void Awake()
    {
        _state = State.Idle;
    }

    private void Start()
    {
        pathfindingMovement.speed = enemyInfo.Speed;
        pathfindingMovement.angularSpeed = enemyInfo.AngularSpeed;
        pathfindingMovement.acceleration = enemyInfo.Acceleration;
    }

    private void Update()
    {
        switch (_state)
        {
            case State.Idle:
                FindTarget();
                break;
            case State.ChaseTarget:

                pathfindingMovement.SetDestination(Player.Instance.GetPosition());

                if (Vector3.Distance(transform.position, Player.Instance.GetPosition()) < enemyInfo.AttackRange)
                {
                    pathfindingMovement.isStopped = true;
                    if (Time.time > _nextShootTime)
                    {
                        enemyAttack.Attack(Player.Instance);
                        _nextShootTime = Time.time + enemyInfo.ImpactSpeed;
                    }
                }
                else
                {
                    enemyAttack.isAtack(false);
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
        if (Vector3.Distance(transform.position, Player.Instance.GetPosition()) < enemyInfo.TargetRange)
        {
            _state = State.ChaseTarget;
        }
    }
}