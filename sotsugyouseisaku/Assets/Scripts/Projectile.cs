using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    AttackManager attackManager_;
    public GameObject impact_vfx;

    private void Start()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("Player");
        attackManager_ = obj.GetComponentInChildren<AttackManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Bullet") && !other.CompareTag("Player") && !other.CompareTag("Item"))
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

            Vector3  contactPoint = other.transform.position;

            var impact = Instantiate(impact_vfx, contactPoint, Quaternion.identity) as GameObject;

            Destroy(impact, 2);
            Destroy(gameObject);
        }

       
    }
}
