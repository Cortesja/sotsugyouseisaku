using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    private AttackManager attackerManager_;

    private void Start()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("Player");
        attackerManager_ = obj.GetComponentInChildren<AttackManager>();
    }
}
