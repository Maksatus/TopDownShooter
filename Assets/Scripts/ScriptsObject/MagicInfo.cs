using UnityEngine;

[CreateAssetMenu(fileName = "MagicInfo",menuName = "ScriptableObject/new MagicInfo")]
public class MagicInfo : ScriptableObject
{
    [SerializeField] private string id;
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject impact;
    [SerializeField] private int damage;
    [SerializeField] private float speed;
    [SerializeField] private float fireRate;
    [SerializeField] private float arcRange;
    [SerializeField] private float explosionRange;
    [SerializeField] private float lifeTime;
    [SerializeField] private float timeCast;
    [SerializeField] private Vector3 spawOffset;
    public string Id => this.id;
    public GameObject Projectile => projectile;
    public GameObject Impact => impact;
    public float Speed => speed;
    public int Damage => damage;
    public float FireRate => fireRate;
    public float ArcRange => arcRange;
    public float ExplosionRange => explosionRange;
    public float LifeTime => lifeTime;
    public float TimeCast => timeCast;
    public Vector3 SpawOffset => spawOffset;
}