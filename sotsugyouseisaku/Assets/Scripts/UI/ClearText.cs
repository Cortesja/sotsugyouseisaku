using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ClearText : IText
{
    public override void TextMove()
    {
         elapsedTime += Time.deltaTime;
        float easeT = elapsedTime / duration;

        easeT = Mathf.Clamp01(easeT);

        transform.position = Vector3.Lerp(begin, end, Easing.InOutQuart(easeT));
    }

    // Start is called before the first frame update
    void Start()
    {
        begin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       this.TextMove();
    }
}
