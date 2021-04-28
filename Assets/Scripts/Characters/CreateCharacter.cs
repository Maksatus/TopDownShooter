using Cinemachine;
using UnityEngine;

public class CreateCharacter : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private CharacterInfo _characterInfo;
    [SerializeField] private CinemachineVirtualCamera _camera;
    private void Start()
    {
        Init();
    }
    [ContextMenu("InitCharacter")]
    public void Init()
    {
        var character = Instantiate(_characterInfo.GameObject,spawnPoint);
        _camera.Follow = character.transform;
    }
}
