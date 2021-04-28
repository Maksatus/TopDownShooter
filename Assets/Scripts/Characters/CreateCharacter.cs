using Cinemachine;
using UnityEngine;

public class CreateCharacter : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private CharacterInfo characterInfo;
    [SerializeField] private CinemachineVirtualCamera cameraMain;
    private void Start()
    {
        
        Init();
    }
    [ContextMenu("InitCharacter")]
    public void Init()
    {
        var character = Instantiate(characterInfo.GameObject,spawnPoint);
        cameraMain.Follow = character.transform;
    }
}
