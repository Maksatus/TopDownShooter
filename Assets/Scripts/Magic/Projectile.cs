using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private MagicInfo magicInfo;
    public MagicInfo MagicInfo => magicInfo;

    private void OnEnable()
    {
        StartCoroutine(LifeRoutine());
    }
    private void OnDisable()
    {
        StopCoroutine(LifeRoutine());
        Destroy(gameObject);
    }

    private IEnumerator LifeRoutine()
    {
        yield return new WaitForSecondsRealtime(magicInfo.LifeTime);
        Deactivate();
    }
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent<EnemyAI>(out var enemy))
        {
            var impact = Instantiate(magicInfo.Impact, other.contacts[0].point, Quaternion.identity);
            Destroy(impact,2f);
        }
    }
}
