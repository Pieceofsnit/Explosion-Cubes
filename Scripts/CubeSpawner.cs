using UnityEngine;

[RequireComponent (typeof(Explosion))]

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Vector3 _scaleCube;
    [SerializeField] private Cube _cubePrefab;

    private Explosion _explosion;
    private int _minAmount = 5;
    private int _maxAmount = 6;
    private float _delimiterScale = 2f;
    private float _splitChanceDelimiter = 2f;
    private float _splitChance = 1f;
    private float _explosionForce;
    private float _explosionRadius;
    private float _forceMultiplier = 2f;

    private void Awake()
    {
        _explosion = GetComponent<Explosion>();
    }

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
        _splitChance = _cubePrefab.ChanceSplit;
        _splitChance = _splitChance /= _splitChanceDelimiter;
        _scaleCube = transform.localScale /= _delimiterScale;
        _explosionForce = _explosion.ExplosionForce *= _forceMultiplier;
        _explosionRadius = _explosion.ExplosionRadius *= _forceMultiplier;
    }

    private void SpawnCubes()
    {
        int randomAmountCubes = Random.Range(_minAmount, _maxAmount);
        
        for (int i = 0; i < randomAmountCubes; i++)
        {
            Cube cube = Instantiate(_cubePrefab, transform.position, transform.rotation);
            cube.Initialize(_scaleCube, transform.position, Random.ColorHSV(), _splitChance);
            _explosion.Explode(_explosionForce, _explosionRadius);
        }
    }
}
