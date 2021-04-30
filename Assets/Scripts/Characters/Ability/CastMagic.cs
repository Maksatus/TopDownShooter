using System.Collections;
using UnityEngine;

namespace Characters.Ability
{
    public class CastMagic : MonoBehaviour
    {
        private Player _player;

        private Vector3 _destination;
        private void Start()
        {
            _player = Player.Instance;
        }

        public void ShootProjectile(MagicInfo magicInfo)
        {
            StartCoroutine(ToWait(magicInfo));
        }
        private IEnumerator ToWait(MagicInfo magicInfo)
        {
            yield return new WaitForSecondsRealtime(magicInfo.TimeCast);
            if (_player.GetNavMeshAgent().velocity.magnitude>0.1f)
            {
                yield break;
            }
            var ray = new Ray(_player.GetTransformStartPosition().position, _player.GetTransformStartPosition().forward);
            _destination = Physics.Raycast(ray, out var hit) ? hit.point : ray.GetPoint(50f);
            InstantiateMagic(magicInfo);
            
    }
        private void InstantiateMagic(MagicInfo magicInfo)
        {
            var position = _player.GetTransformStartPosition().position + (_player.GetTransformStartPosition().forward * magicInfo.SpawnOffset);
            Debug.Log(position);
            var magic = Instantiate(magicInfo.Projectile, position, Quaternion.identity);
            if (magic.GetComponent<Rigidbody>()!=null)
            {
                magic.GetComponent<Rigidbody>().velocity = (_destination - position).normalized * magicInfo.Speed;
                RandomMoveProjectile(magic,magicInfo.ArcRange);
            }
        }
        private void RandomMoveProjectile(GameObject gameObject, float rangeTransform, float startTime = 0.2f, float endTime = 1f)
        {
            iTween.PunchPosition(gameObject,new Vector3(Random.Range(-rangeTransform,rangeTransform),0,0),Random.Range(startTime,endTime));
        }
    }    
}

