using UnityEngine;

namespace Health
{
    public class EnemyLives : MonoBehaviour
    {
        [SerializeField] private EnemyInfo enemyInfo;

        private HealthSystem _healthSystem;
        private void Start()
        {
             _healthSystem = new HealthSystem(enemyInfo.Health);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent<Projectile>(out Projectile projectile))
            {
               _healthSystem.Damage(projectile.MagicInfo.Damage);
            }
            if (_healthSystem.GetHealth()<=0)
            {
                Destroy(gameObject);
            }
        }
    }   
}
