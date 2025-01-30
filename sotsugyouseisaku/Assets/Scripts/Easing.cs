using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Easing : MonoBehaviour
{
    public static float OutCubic(float x)
    {
        float d1 = x - 1;
        return 1 - Mathf.Pow(1 - x, 3);
    }

    public static float InOutQuart(float x)
    {
        if (x < 0.5f)
        {
            return 8 * Mathf.Pow(x, 4);
        }else
        {
            return 1 - Mathf.Pow(-2 * x + 2, 4) / 2;
        }
    }

    public static float InOutExpo(float x)
    {
        if(x == 0){
            return 0.0f;
        }
        if(x == 1)
        {
            return 1.0f;
        }
        if(x < 0.5f)
        {
            return Mathf.Pow(2, 20 * x - 10) / 2;
        }
        else
        {
            return (2 - Mathf.Pow(2, -20 * x + 10)) / 2;
        }
    }

    public static float OutBounce(float x)
    {
        const float n1 = 7.5625f;
        const float d1 = 2.75f;

        if (x < 1 / d1)
        {
            return n1 * Mathf.Pow(x ,2);
        }
        else if (x < 2 / d1)
        {
            return n1 * (x -= 1.5f / d1) * x + 0.75f;
        }
        else if (x < 2.5f / d1)
        {
            return n1 * (x -= 2.25f / d1) * x + 0.9375f;
        }
        else
        {
            return n1 * (x -= 2.625f / d1) * x + 0.984375f;
        }
    }

}
