using UnityEngine;

namespace Characters.Ability
{
    public class AbilitySystem : MonoBehaviour
    {
        [SerializeField] private MagicInfo[] magicInfo;
        [SerializeField] private CastMagic castMagic;
        
        private float _timeToFire; 
        void Update()
        {
           Cast();
        }
        private void Cast()
        {
            if (Input.GetMouseButton(1) && Time.time >= _timeToFire)
            {
                _timeToFire = Time.time + 1 / magicInfo[0].FireRate;
                castMagic.ShootProjectile(magicInfo[0]);
            }
            else if (Input.GetKeyDown(KeyCode.Q) && Time.time >= _timeToFire)
            {
                _timeToFire = Time.time + 1 / magicInfo[1].FireRate;
                castMagic.ShootProjectile(magicInfo[1]);
            }
        }
    }
    
}

