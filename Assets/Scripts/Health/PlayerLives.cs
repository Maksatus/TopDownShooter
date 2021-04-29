using UnityEngine;

namespace Health
{
    public class PlayerLives : MonoBehaviour
    {
        private HealthSystem _healthSystem;
        private void Start()
        {
            _healthSystem = new HealthSystem(100);
        }
        

        public void HitPlayer(int damageAmount)
        {
            _healthSystem.Damage(damageAmount);
            HealthSystemUI.Instance.TakeDamage(damageAmount);
        }
        private void HealMe(int healAmount)
        {
            HealthSystemUI.Instance.HealDamage(healAmount);
        }
    }
}