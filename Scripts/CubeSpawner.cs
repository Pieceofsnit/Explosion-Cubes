using Unity.VisualScripting;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Vector3 _scaleCube;
    [SerializeField] private Cube _cube;
    [SerializeField] private Explosion _explosion;
    private int _minAmount = 5;
    private int _maxAmount = 6;
    private float _delimiterScale = 2f;
    private float _splitChanceDelimiter = 2f;
    private float _splitChance = 1f;
    private float _explosionForce;
    private float _explosionRadius;
    private float _forceMultiplier = 2f;

    private void OnMouseUpAsButton()
    {
        CalculateParameters();

        if (_splitChance >= Random.value)
        {
            SpawnCubes();
        }
        else
        {
            _explosion.Explode(_explosionForce, _explosionRadius);
        }

        Destroy(gameObject);
    } 

    private void CalculateParameters()
    {
        _splitChance = _cube.ChanceSplit /= _splitChanceDelimiter;
        _scaleCube = transform.localScale /= _delimiterScale;
        _explosionForce = _explosion.ExplosionForce *= _forceMultiplier;
        _explosionRadius = _explosion.ExplosionRadius *= _forceMultiplier;
    }

    private void SpawnCubes()
    {
        int randomAmountCubes = Random.Range(_minAmount, _maxAmount);
        
        for (int i = 0; i < randomAmountCubes; i++)
        {
            _cube.Initialize(_scaleCube, transform.position, _splitChance);
            Instantiate(_cube, transform.position, transform.rotation);
        }
    }
}
