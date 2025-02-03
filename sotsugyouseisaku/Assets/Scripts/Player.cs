using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider))]

public class Player : MonoBehaviour
{
    private bool hasSpell_;
    public static Player Instance;
    private Health healthComponent_;

    bool isDead_ = false;
    private void Awake()
    {
        Instance = this;
        healthComponent_ = GetComponent<Health>();
    }
    public void SetHasSpell(bool vaule)
    {
        hasSpell_ = vaule;
    }
    public bool GetHasSpell() { return hasSpell_; }

    public bool GetIsDead() { return isDead_; }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Enemy")) { return; }

        if (other.CompareTag("Enemy"))
        {
            bool hasHealth = TryGetComponent(out healthComponent_);
            if (hasHealth)
            {
                healthComponent_.Damage(1);
                if (GetIsDead())
                {
                    SceneManager.LoadScene("GameOverScene");
                }
            }
        }
    }
}
