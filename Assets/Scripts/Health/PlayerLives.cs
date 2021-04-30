using UnityEngine;

namespace Health
{
    public class PlayerLives : MonoBehaviour
    {
        private HealthSystem _healthSystem;
        private GameManager _gameManager;
        
        
        private void Start()
        {
            _gameManager = GameManager.Instance;
            _healthSystem = new HealthSystem(100);
        }
        

        public void HitPlayer(int damageAmount)
        {
            _healthSystem.Damage(damageAmount);
            HealthSystemUI.Instance.TakeDamage(damageAmount);
            if (_healthSystem.GetHealth()<=0)
            {
                _gameManager.GameOver();
            }
        }
        private void HealMe(int healAmount)
        {
            HealthSystemUI.Instance.HealDamage(healAmount);
        }
    }
}