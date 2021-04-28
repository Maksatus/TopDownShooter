using UnityEngine;

[CreateAssetMenu(fileName = "CharacterInfo",menuName = "ScriptableObject/new CharacterInfo")]
public class CharacterInfo : ScriptableObject
{
    [SerializeField] private string id;
    [SerializeField] private GameObject gameObject;
    [SerializeField] private float speed;
    [SerializeField] private float angularSpeed;
    [SerializeField] private float acceleration;

    public string Id => this.id;
    public GameObject GameObject => gameObject;
    public float Speed => speed;
    public float Acceleration => acceleration;
    public float AngularSpeed => angularSpeed;
}
