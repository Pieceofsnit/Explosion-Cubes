using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]

public class Cube : MonoBehaviour
{
    private MeshRenderer _renedererColor;
    private float _chanceSplit = 1f;

    public float ChanceSplit => _chanceSplit;

    private void Awake()
    {
        _renedererColor = GetComponent<MeshRenderer>();
    }

    public void Initialize(Vector3 scale, Vector3 position, Color color, float chanceSplit)
    {
        transform.localScale = scale;
        _renedererColor.material.color = color;
        transform.localPosition = position;
        _chanceSplit = chanceSplit;
    }
}
