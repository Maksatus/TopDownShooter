using UnityEngine;
using UnityEngine.AI;

namespace Health
{
    public class EnemyLives : MonoBehaviour
    {
        [SerializeField] private EnemyInfo enemyInfo;
        [SerializeField] private Animator animator;
        [SerializeField] private NavMeshAgent pathfindingMovement;

        private HealthSystem _healthSystem;
        private static readonly int Death = Animator.StringToHash("Death");
        private void Start()
        {
             _healthSystem = new HealthSystem(enemyInfo.Health);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent<Projectile>(out var projectile))
            {
               _healthSystem.Damage(projectile.MagicInfo.Damage);
            }
            if (_healthSystem.GetHealth()<=0)
            {
                pathfindingMovement.speed = 0;
                animator.SetTrigger(Death);
                Destroy(gameObject,3f);
            }
        }
    }   
}
