using UnityEngine;

public class CastMagic : MonoBehaviour
{
    [SerializeField] private MagicInfo magicInfo;
    [SerializeField] private Transform startPoint;

    private Vector3 _destination;
    private float _timeToFire;
    void Update()
    {
        Debug.DrawRay(startPoint.position,startPoint.forward,Color.magenta);

        if (Input.GetMouseButton(1) && Time.time >= _timeToFire)
        {
            _timeToFire = Time.time + 1 / magicInfo.FireRate;
            ShootProjectile();
        }
    }
    private void ShootProjectile()
    {
        Ray ray = new Ray(startPoint.position, startPoint.forward);

        _destination = Physics.Raycast(ray,out var hit) ? hit.point : ray.GetPoint(50f);

        InstantiateMagic(startPoint);
    }
    private void InstantiateMagic(Transform firePoint)
    {
        var magic = Instantiate(magicInfo.Projectile, firePoint.position, Quaternion.identity);
        magic.GetComponent<Rigidbody>().velocity = (_destination - firePoint.position).normalized * magicInfo.Speed;

        RandomMoveProjectile(magic,magicInfo.ArcRange);
    }
    private void RandomMoveProjectile(GameObject gameObject, float rangeTransform, float startTime = 0.2f, float endTime = 1f)
    {
        iTween.PunchPosition(gameObject,new Vector3(Random.Range(-rangeTransform,rangeTransform),0,0),Random.Range(startTime,endTime));
    }
}
