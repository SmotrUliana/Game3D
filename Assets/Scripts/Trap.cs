using System;
using UnityEngine;
using System.Collections;

public class Trap : MonoBehaviour
{
    [SerializeField]
    private float _killingInterval;
    [SerializeField]
    private float _movingTime;
    [SerializeField]
    private float _groundedTime;
    [SerializeField]
    private GameObject _vfx;
    [SerializeField]
    private float _damage;

    private bool _isMoving = false;
    private float _lastActivationTime;
    private bool _inProgressOfKilling;

    public float KillingIntervalProgress 
    { 
        get 
        { 
            if (_inProgressOfKilling)
            {
                return 0;
            }
            return Mathf.Clamp01((Time.time - _lastActivationTime) / _killingInterval);
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<Health>(out var health))
        {
            health.TakeDamage(_damage);
        }
    }

    private void Start()
    {
        StartCoroutine(ActivateTrap());
        _lastActivationTime = Time.time;
    }

    private IEnumerator ActivateTrap()
    {
        while (true)
        {
            yield return new WaitForSeconds(_killingInterval);
            _lastActivationTime = Time.time;

            if (!_isMoving)
            {
                StartCoroutine(MoveTrap());
            }
        }
    }

    private IEnumerator MoveTrap()
    {
        _isMoving = true;

        float elapsedTime = 0;
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = transform.parent.position;

        _inProgressOfKilling = true;

        while (elapsedTime < _movingTime)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, (elapsedTime / _movingTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Instantiate(_vfx, transform.position, Quaternion.identity);
        transform.position = targetPosition;

        yield return new WaitForSeconds(_groundedTime);
        
        _inProgressOfKilling = false;

        elapsedTime = 0;
        while (elapsedTime < _movingTime)
        {
            transform.position = Vector3.Lerp(targetPosition, startPosition, (elapsedTime / _movingTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = startPosition;

        _isMoving = false;
    }
}
