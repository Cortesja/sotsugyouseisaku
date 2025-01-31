using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleText : IText
{

    public override void TextMove()
    {
        elapsedTime += Time.deltaTime;
        float easeT = elapsedTime / duration;

        easeT = Mathf.Clamp01(easeT);

        transform.position = Vector3.Lerp(begin, end, Easing.OutBounce(easeT));
    }

    void Start()
    {
        begin = transform.position;
    }

    void Update()
    {
        this.TextMove();
    }
}
