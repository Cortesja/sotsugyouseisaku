using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth_;
    private float currentHealth_;
    private Collider collider_;

    private void Awake()
    {
        currentHealth_ = maxHealth_;
        collider_ = GetComponent<Collider>();
    }

    public void Damage(float point)
    {
        currentHealth_ -= point;
        if (currentHealth_ > 0) { return; }
        Death();
    }
    private void Death()
    {
        Destroy(gameObject);
    }
}
