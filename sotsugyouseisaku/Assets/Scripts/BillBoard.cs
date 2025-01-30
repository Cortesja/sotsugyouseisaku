using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    // ‘Ì—Íƒo[‚ğƒJƒƒ‰‚ÉŒü‚©‚¹‚é‚½‚ß  v
    private void LateUpdate()
    {
        if(Camera.main != null)
        {
            //Debug.Log("Billboard script running on: " + gameObject.name);
            transform.LookAt(Camera.main.transform, Vector3.up);
        }
    }
}
