using System;
using UnityEngine;

namespace Characters.Ability
{
    public class AbilitySystem : MonoBehaviour
    {
        [SerializeField] private MagicInfo[] magicInfo;
        [SerializeField] private CastMagic castMagic;
        
        private float[] _timeToFire;

        private void Start()
        {
            _timeToFire = new float[magicInfo.Length];
        }
        private void Update()
        {
           Cast();
        }
        private void Cast()
        {
            if (Input.GetMouseButtonDown(1) && Time.time >= _timeToFire[0])
            {
                _timeToFire[0] = Time.time + magicInfo[0].FireRate;
                castMagic.ShootProjectile(magicInfo[0]);
            }
            else if (Input.GetKeyDown(KeyCode.Q) && Time.time >= _timeToFire[1])
            {
                _timeToFire[1] = Time.time + magicInfo[1].FireRate;
                castMagic.ShootProjectile(magicInfo[1]);
            }
        }
    }
}

