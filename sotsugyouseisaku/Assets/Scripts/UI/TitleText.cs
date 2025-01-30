using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleText : MonoBehaviour
{
    [SerializeField] private Vector3 end;
    private float duration = 1.25f;
    
    private Vector3 begin;
    private float elapsedTime = 0.0f;

    void Start()
    {
        begin = transform.position;
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        float easeT = elapsedTime / duration;

        if (easeT > 1.0f) easeT = 1f;

        transform.position = Vector3.Lerp(begin, end, Easing.OutBounce(easeT));
    }
}
