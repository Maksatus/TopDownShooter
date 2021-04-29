using UnityEngine;

[CreateAssetMenu(fileName = "EnemyInfo", menuName = "ScriptableObject/new EnemyInfo", order = 0)]
public class EnemyInfo : ScriptableObject
{
    [SerializeField] private string id;
    [SerializeField] private GameObject gameObject;
    [SerializeField] private float speed;
    [SerializeField] private float angularSpeed;
    [SerializeField] private float acceleration;
    [SerializeField] private int damageValue;
    [SerializeField] private int health;
    [SerializeField] private int attackRange;
    [SerializeField] private int targetRange;
    [SerializeField] private float impactSpeed;
    [SerializeField] private float animationSpeed;

    public string Id => this.id;
    public GameObject GameObject => gameObject;
    public float Speed => speed;
    public float Acceleration => acceleration;
    public float AngularSpeed => angularSpeed;
    public int DamageValue => damageValue;
    public float AttackRange => attackRange;
    public int Health => health;
    public int TargetRange => targetRange;
    public float ImpactSpeed => impactSpeed;
    public float AnimationSpeed => animationSpeed;
    
}