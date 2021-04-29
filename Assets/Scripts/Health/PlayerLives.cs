using UnityEngine;

namespace Health
{
    public class PlayerLives : MonoBehaviour
    {
        [SerializeField] private HealthBar healthBar;
        private void Start()
        {
            HealthSystem healthSystem = new HealthSystem(100);
            healthBar.Setup(healthSystem);
            
            Debug.Log("Health" + healthSystem.GetHealth());
            healthSystem.Damage(30);
            Debug.Log("Health" + healthSystem.GetHealth());
            healthSystem.Heal(20);
            Debug.Log("Health" + healthSystem.GetHealth());
        }
    }
}