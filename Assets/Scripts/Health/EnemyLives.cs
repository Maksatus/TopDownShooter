using UnityEngine;
using UnityEngine.AI;

namespace Health
{
    public class EnemyLives : MonoBehaviour
    {
        [SerializeField] private EnemyInfo enemyInfo;
        [SerializeField] private Animator animator;
        [SerializeField] private NavMeshAgent pathfindingMovement;
        [SerializeField] private GameObject vfxObject;

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
                var obj = Instantiate(vfxObject,transform.position, Quaternion.identity);
                pathfindingMovement.speed = 0;
                animator.SetTrigger(Death);
                Destroy(gameObject,2.7f);
                Destroy(obj,4f);
            }
        }
    }   
}
