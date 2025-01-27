using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    //private Camera camera_;
    //Vector3 mousePos_;

    private Cursor cursor_;

    private const string FLOOR_LAYER_NAME = "Floor";

    private Vector3 destination_;
    private Vector3 lookAtPoint_;
    private float speed_ = 30.0f; 
    public Transform player_;

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
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit raycastHit;
        //bool isHit = Physics.Raycast(
        //    ray,
        //    out raycastHit,
        //    1000,
        //    LayerMask.GetMask(FLOOR_LAYER_NAME));

        //if (isHit)
        //{
        //    destination_ = raycastHit.point;
        //}

        //RaycastHit hit;

        //if (Physics.Raycast(ray, out hit))
        //{
        //    destination_ = hit.point;
        //}
        //else
        //{
        //    destination_ = ray.GetPoint(1000);
        //}

        Ray ray = cursor_.GetRay();
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            destination_ = hit.point;
        }
        else
        {
            destination_ = ray.GetPoint(1000);
        }

        ////////////////////////////////////////////////////////

        Vector3 cursorPoint = cursor_.GetRaycastHit().point;
        Vector3 toCamera = -cursor_.GetRay().direction;
        float dot = Vector3.Dot(Vector3.up, toCamera);
        float angleRad = Mathf.Acos(dot);
        float h = player_.position.y - cursorPoint.y;
        float cLength = h / Mathf.Cos(angleRad);
        lookAtPoint_ = cursorPoint + toCamera * cLength;
        transform.LookAt(lookAtPoint_);

        ///////////////////////////////////////////////////////////

        //debug
        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.red, 2.0f);

        InstantiateProjectile(player_);
    }

    void InstantiateProjectile(Transform player)
    {
        //adjust y value so that can see
        Vector3 offset = player_.position;
        offset.y += 1.0f;
        var projectileObj = Instantiate(projectile_, offset, Quaternion.identity) as GameObject;
        projectileObj.GetComponent<Rigidbody>().velocity = (destination_ - player_.position).normalized * speed_;


    }
}
