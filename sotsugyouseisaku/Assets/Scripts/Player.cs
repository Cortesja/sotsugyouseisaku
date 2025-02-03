using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool hasSpell_;
    public static Player Instance;
    private void Awake()
    {
        Instance = this;
    }
    public void SetHasSpell(bool vaule)
    {
        hasSpell_ = vaule;
    }
    public bool GetHasSpell() { return hasSpell_; }
}
