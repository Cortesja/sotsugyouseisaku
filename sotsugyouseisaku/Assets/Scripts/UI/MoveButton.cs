using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButton : MonoBehaviour
{

    private Vector3 begin;
    private Vector3 end;

    private float elapesdTime = 0.0f;
    private float duration = 1.25f;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = Vector3.zero;
        begin = transform.localScale;
        end = Vector3.one;
    }

    // Update is called once per frame
    void Update()
    {
        elapesdTime += Time.deltaTime;
        float easeT = elapesdTime / duration;

        if (easeT > 1.0f) easeT = 1.0f;

        transform.localScale = Vector3.Lerp(begin, end, Easing.InOutExpo(easeT));

    }
}
