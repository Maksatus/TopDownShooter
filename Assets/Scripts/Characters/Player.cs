using Characters.Ability;
using Health;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    
    [SerializeField] private PlayerLives playerLives;
    [SerializeField] private CastMagic castMagic;
    [SerializeField] private Animator animator;
    [SerializeField] private CharacterInfo characterInfo;
    [SerializeField] private Camera cameraMain;
    [SerializeField] private float speedRotate = 6f;
    [SerializeField] private Transform startPoint;
    [SerializeField] private NavMeshAgent navMeshAgent;
    
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        cameraMain = Camera.main;
    }
    public Vector3 GetPosition()
    {
        return transform.position;
    }
    public PlayerLives GetHealthPlayer()
    {
        return playerLives;
    }

    public Animator GetAnimator()
    {
        return animator;
    }
    public CastMagic GetCastMagic()
    {
        return castMagic;
    }
    public CharacterInfo GetCharacterInfo()
    {
        return characterInfo;
    }
    public Camera GetCameraMain()
    {
        return cameraMain;
    }
    public float GetSpeedRotate()
    {
        return speedRotate;
    }
    public Transform GetTransformStartPosition()
    {
        return startPoint;
    }
    public NavMeshAgent GetNavMeshAgent()
    {
        return navMeshAgent;
    }
}
