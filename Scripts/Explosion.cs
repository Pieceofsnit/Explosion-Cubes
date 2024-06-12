using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float ExplosionRadius;
    public float ExplosionForce;

    public void Explode(float explosionForce, float explosionRadius)
    {
        foreach (Rigidbody explodableObject in GetExplodableObject(explosionRadius))
        {
            explodableObject.AddExplosionForce(explosionForce, transform.position, explosionRadius);
        }
    }

    private List<Rigidbody> GetExplodableObject(float explosionRadius)
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, explosionRadius);

        List<Rigidbody> cube = new();

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
            {
                cube.Add(hit.attachedRigidbody);
            }
        }

        return cube;
    }
}
