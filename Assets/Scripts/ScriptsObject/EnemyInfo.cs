using UnityEngine;

[CreateAssetMenu(fileName = "EnemyInfo", menuName = "ScriptableObject/new EnemyInfo", order = 0)]
public class EnemyInfo : ScriptableObject
{
    [SerializeField] private string id;
    [SerializeField] private GameObject gameObject;
    [SerializeField] private float speed;
    [SerializeField] private float angularSpeed;
    [SerializeField] private float acceleration;
    [SerializeField] private float damageValue;
    [SerializeField] private int health;

    public string Id => this.id;
    public GameObject GameObject => gameObject;
    public float Speed => speed;
    public float Acceleration => acceleration;
    public float AngularSpeed => angularSpeed;
    public float DamageValue => damageValue;
    public int Health => health;
    
}