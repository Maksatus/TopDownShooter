using System.Collections;
using UnityEngine;

namespace Characters.Ability
{
    public class CastMagic : MonoBehaviour
    {
        [SerializeField] private Transform startPoint;

        private Vector3 _destination;

        public void ShootProjectile(MagicInfo magicInfo)
        {
            StartCoroutine(ToWait(magicInfo));
        }
        private void InstantiateMagic(MagicInfo magicInfo)
        {
            var position = startPoint.position;
            var magic = Instantiate(magicInfo.Projectile, position, Quaternion.identity);
            magic.GetComponent<Rigidbody>().velocity = (_destination - position).normalized * magicInfo.Speed;

            RandomMoveProjectile(magic,magicInfo.ArcRange);
        }
        private void RandomMoveProjectile(GameObject gameObject, float rangeTransform, float startTime = 0.2f, float endTime = 1f)
        {
            iTween.PunchPosition(gameObject,new Vector3(Random.Range(-rangeTransform,rangeTransform),0,0),Random.Range(startTime,endTime));
        }

        IEnumerator ToWait(MagicInfo magicInfo)
        { 
            yield return new WaitForSecondsRealtime(0.3f);
            Ray ray = new Ray(startPoint.position, startPoint.forward);
            _destination = Physics.Raycast(ray,out var hit) ? hit.point : ray.GetPoint(50f);
            InstantiateMagic(magicInfo);
        }
    }    
}

