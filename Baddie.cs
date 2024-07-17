using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baddie : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 3f;
    [SerializeField] private float _damageThreshold = 0.2f;

    private float _currentHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void DamageBuddie(float damageAmount)
    {
        _currentHealth -= damageAmount;

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        GameManager.Instance.RemoveBaddie(this);

        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float impactVelocity = collision.relativeVelocity.magnitude;
        if (impactVelocity > _damageThreshold)
        {
            DamageBuddie(impactVelocity);
        }
    }
}
