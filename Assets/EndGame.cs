using UnityEngine;
public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject endUi;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (other.gameObject.TryGetComponent<Player>(out var player))
        {
            endUi.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
