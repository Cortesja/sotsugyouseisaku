using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    //private Camera camera_;
    //Vector3 mousePos_;

    Vector3 temp;

    private Cursor cursor_;

    private const string FLOOR_LAYER_NAME = "Floor";

    private Vector3 lookAtPoint_;
    private float speed_ = 30.0f;

    [SerializeField, Header("Prefabs")]
    private FireBall fireballPrefab_;
    [SerializeField] GameObject projectile_;

    // Start is called before the first frame update
    void Start()
    {
        Camera.main.TryGetComponent<Cursor>(out cursor_);
        Assert.IsTrue(cursor_ != null, "Cursor not found");
        GameObject cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
        Assert.IsNotNull(cameraObject);
        bool isFindCursor = cameraObject.TryGetComponent(out cursor_);
        Assert.IsTrue(isFindCursor);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ShootProjectile();
        }
    }

    void ShootProjectile()
    {
        ////////////////////////////////////////////////////////

        Vector3 cursorPoint = cursor_.GetRaycastHit().point;
        Vector3 toCamera = -cursor_.GetRay().direction;
        float dot = Vector3.Dot(Vector3.up, toCamera);
        float angleRad = Mathf.Acos(dot);
        float h = transform.position.y - cursorPoint.y;
        float cLength = h / Mathf.Cos(angleRad);
        lookAtPoint_ = cursorPoint + toCamera * cLength;

        transform.LookAt(lookAtPoint_);

        ///////////////////////////////////////////////////////////

        //debug
        Debug.DrawRay(cursor_.GetRay().origin, cursor_.GetRay().direction * 1000, Color.red, 2.0f);
        Debug.DrawRay(transform.position, transform.forward * 100, Color.green, 2.0f);

        InstantiateProjectile();
    }

    void InstantiateProjectile()
    {
        var projectileObj = Instantiate(projectile_, transform.position, Quaternion.identity) as GameObject;
       projectileObj.GetComponent<Rigidbody>().velocity = transform.forward * speed_;
    }
}
