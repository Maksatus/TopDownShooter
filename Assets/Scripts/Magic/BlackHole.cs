using UnityEngine;

public class BlackHole : MonoBehaviour
{
    [SerializeField] private MagicInfo magicInfo;
    [SerializeField] private LayerMask layerMask;
    
    private void Update()
    {
        var enemy = Physics.OverlapSphere(transform.position, magicInfo.ExplosionRange,layerMask);
        foreach (var obj in enemy)
        {
            if (obj.GetComponent<Rigidbody>()!=null)
            {
                var position = obj.gameObject.transform.position;

                obj.gameObject.GetComponent<Rigidbody>().AddForce((transform.position -position).normalized * 40f);
            }
        }
    }
}
