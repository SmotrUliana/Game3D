using UnityEngine;

public class Lava : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<Health>(out var health))
            health.TakeDamage(health.Current);
    }
}