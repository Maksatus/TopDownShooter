using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
