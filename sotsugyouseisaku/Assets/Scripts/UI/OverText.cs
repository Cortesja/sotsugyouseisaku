using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverText : MonoBehaviour
{
    private Vector3 begin;

    [SerializeField]private Vector3 end;

    private float duration = 1.25f;
    private float elapsedTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        begin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        float easeT = elapsedTime / duration;

        if(easeT > 1.0f) easeT = 1.0f;

        transform.position = Vector3.Lerp(begin, end, Easing.InOutQuart(easeT));
    }
}
