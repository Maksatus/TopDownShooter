using UnityEngine;

public class BlackHole : MonoBehaviour
{
    [SerializeField] private MagicInfo magicInfo;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Collider[] results;
    [SerializeField] private int maxEnemyForce = 10;

    private void Awake()
    {
        results = new Collider[maxEnemyForce];
    }
    private void Update()
    {
        var size = Physics.OverlapSphereNonAlloc(transform.position, magicInfo.ExplosionRange, results, layerMask);
        for (int i = 0; i < size; i++)
        {
            if (results[i].GetComponent<Rigidbody>() != null)
            {
                var position = results[i].gameObject.transform.position;
                results[i].gameObject.GetComponent<Rigidbody>().AddForce((transform.position - position).normalized * 35f);
            }
        }
    }
    private void OnDisable()
    {
        foreach (var obj in results)
        {
            if (obj!=null)
            {
                obj.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }
}
