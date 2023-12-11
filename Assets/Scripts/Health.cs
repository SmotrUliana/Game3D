using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float _maxHp;
    
    public float Current { get; private set; }
    public float MaxHp => _maxHp;

    private void Awake()
    {
        Current = _maxHp;
    }

    public void TakeDamage(float damage)
    {
        Current -= damage;
    }
}