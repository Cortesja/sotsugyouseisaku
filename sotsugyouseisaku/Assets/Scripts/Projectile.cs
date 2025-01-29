using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    AttackManager attackManager_;

    private void Start()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("Player");
        attackManager_ = obj.GetComponentInChildren<AttackManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Health healthComponent;
            bool hasHealth = other.TryGetComponent(out healthComponent);
            if (hasHealth)
            {
                healthComponent.Damage(attackManager_.GetSpellDmg());
            }
        }
        if(!other.CompareTag("Bullet") && !other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
