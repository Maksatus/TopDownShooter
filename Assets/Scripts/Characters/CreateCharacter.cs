using System.Collections;
using Cinemachine;
using UnityEngine;

public class CreateCharacter : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private CharacterInfo characterInfo;
    [SerializeField] private CinemachineVirtualCamera cameraMain;
    [SerializeField] private float starTime = 8f;

        private GameObject _player;
    private void Start()
    {
        Init();
    }
    [ContextMenu("InitCharacter")]
    public void Init()
    {
         _player = Instantiate(characterInfo.GameObject,spawnPoint);
        cameraMain.Follow = _player.transform;
        _player.SetActive(false);
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(starTime);
        _player.SetActive(true);
    }
}
