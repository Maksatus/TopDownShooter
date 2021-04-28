using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private GameObject impactVfx;
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag.Contains("Enemy"))
        {
            var impact = Instantiate(impactVfx, other.contacts[0].point, Quaternion.identity);
            Destroy(impact,2f);
            Destroy(gameObject);
        }
    }
}
