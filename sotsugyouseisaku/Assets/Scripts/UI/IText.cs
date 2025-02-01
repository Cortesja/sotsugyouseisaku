using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IText : MonoBehaviour
{
    protected Vector3 begin;
    [SerializeField] protected Vector3 end;

    protected float duration = 1.25f;
    protected float elapsedTime = 0.0f;

    public abstract void TextMove();

}
