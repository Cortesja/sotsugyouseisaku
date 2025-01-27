using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleText : MonoBehaviour
{
    [SerializeField] private Vector3 end;

    private float duration = 0.2f;

    void Start()
    {
        
    }

    void Update()
    {
        this.Linear();
    }

    private void Linear()
    {
        Vector3 begin = transform.position;
        if(Vector3.Distance(begin,end) < 0.01f)
        {
            return;
        }
        transform.position = Vector3.Lerp(begin, end, Easing.InSine(duration));
    }
}
