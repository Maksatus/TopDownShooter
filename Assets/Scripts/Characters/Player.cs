using Health;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField] private  PlayerLives playerLives;
    private void Awake()
    {
        Instance = this;
    }
    public Vector3 GetPosition()
    {
        return transform.position;
    }
    public PlayerLives GetHealthPlayer()
    {
        return playerLives;
    }
}
