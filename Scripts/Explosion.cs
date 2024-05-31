using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] float _explosionRadius;
    [SerializeField] float _explosionForce;

    private void Explode()
    {
        foreach (Rigidbody explodableObject in GetExplodableObject())
        {
            explodableObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }

    private List<Rigidbody> GetExplodableObject()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

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
