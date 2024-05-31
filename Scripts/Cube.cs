using UnityEngine;

[RequireComponent(typeof (MeshRenderer))]

public class Cube : MonoBehaviour
{
    private MeshRenderer _renedererColor;

    public float ChanceSplit;

    private void Start()
    {
        _renedererColor = GetComponent<MeshRenderer>();
    }

    public void Initialize(Vector3 scale, Vector3 position, float chanceSplit)
    {
        transform.localScale = scale;
        _renedererColor.material.color = Random.ColorHSV();
        transform.localPosition = position;
        ChanceSplit = chanceSplit;
    }
}
