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
        

        private void HitMe(int damageAmount)
        {
            HealthSystemUI.Instance.TakeDamage(damageAmount);
        }
        private void HealMe(int healAmount)
        {
            HealthSystemUI.Instance.HealDamage(healAmount);
        }
    }
}