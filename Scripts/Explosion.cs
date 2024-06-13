using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private float _explosionRadius = 5f;
    private float _explosionForce = 1000f;

    public void Explode(Cube cube)
    {
        Vector3 explosionPosition = cube.transform.position;
        float explosionRadius = CalculateRadius(cube);
        float explosionForce = CalculateForce(cube);

        Collider[] colliders = Physics.OverlapSphere(transform.position, _explosionRadius);

        foreach (Collider collider in colliders)
        {
            if(collider.TryGetComponent(out Rigidbody rigidbody))
                rigidbody.AddExplosionForce(explosionForce, cube.transform.position, explosionRadius);
        }
    }

    public float CalculateForce(Cube cube)
    {
        return _explosionForce / cube.transform.localScale.magnitude;
    }

    public float CalculateRadius(Cube cube)
    {
        return _explosionRadius * cube.transform.localScale.magnitude;
    }
}
