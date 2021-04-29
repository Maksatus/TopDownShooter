using UnityEngine;

namespace Health
{
    public class HealthBar : MonoBehaviour
    {
        private HealthSystem _healthSystem;
        
        public void Setup(HealthSystem healthSystem)
        {
            _healthSystem = healthSystem;
        }
       
    }   
}
