using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField]
    private Transform _transform;
    private Vector3 _offset;

    void Start()
    {
        _offset = transform.position - _transform.position;
    }

    void LateUpdate()
    {
        transform.position = _transform.position + _offset;
    }
}