using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    private void Update()
    {
        Destroy(gameObject, 2f);
    }
}
