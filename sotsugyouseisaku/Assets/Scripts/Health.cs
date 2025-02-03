using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider))]
public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth_;
    private float currentHealth_;
    private Collider collider_;

    [SerializeField] private Slider healthBar_;
    private void Awake()
    {
        currentHealth_ = maxHealth_;
        collider_ = GetComponent<Collider>();

        UpdateHealth();
    }

    public void Damage(float point)
    {
        currentHealth_ -= point;
        UpdateHealth();
        if (currentHealth_ > 0) { return; }
        Death();
    }

    public void Heal(float point)
    {
        currentHealth_ += point;
        UpdateHealth();
        if (currentHealth_ >= maxHealth_)
        {
            currentHealth_ = maxHealth_;
        }
    }

    private void Death()
    {
        //Destroy(gameObject);
        gameObject.SetActive(false);    
    }

    private void UpdateHealth()
    {
        if (healthBar_ != null)
        {
            healthBar_.value = currentHealth_ / maxHealth_;
        }
    }
}
