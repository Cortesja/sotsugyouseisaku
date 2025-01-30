using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Easing : MonoBehaviour
{
    public static float InSine(float x){
        return 1 - Mathf.Cos((x * Mathf.PI) / 2);
    }
}
