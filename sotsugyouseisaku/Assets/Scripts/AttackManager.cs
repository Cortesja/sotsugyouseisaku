using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    SpellType spellType_;
    private Cursor cursor_;
    private Vector3 lookAtPoint_;
    private float speed_ = 30.0f;
    private int dmg_;

    [SerializeField, Header("Prefabs")]
    private GameObject fireballPrefab_;
    [SerializeField]
    private GameObject thunderPrefab_;
    [SerializeField]
    private GameObject waterPrefab_;

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
        if (Input.GetKeyDown(KeyCode.Mouse0) && Player.Instance.GetHasSpell())
        {
            ShootProjectile();
            Player.Instance.SetHasSpell(false);
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

    public void SetSpell(Item item)
    {
        spellType_ = item.spellType;
    }

    public SpellType GetSpell()
    {
        return spellType_;
    }

    public void SetSpellDmg(Item item)
    {
        dmg_ = item.dmg;
    }
    public int GetSpellDmg()
    {
        return dmg_;
    }

    void InstantiateProjectile()
    {
        GameObject projectileObj;
        switch (spellType_)
        {
            case SpellType.kFire:
                speed_ = 7.0f;
                projectileObj = Instantiate(fireballPrefab_, transform.position, Quaternion.identity)as GameObject;
                projectileObj.GetComponent<Rigidbody>().velocity = transform.forward * speed_;
                break;
            case SpellType.kThunder:
                speed_ = 30.0f;
                projectileObj = Instantiate(thunderPrefab_, transform.position, Quaternion.identity) as GameObject;
                projectileObj.GetComponent<Rigidbody>().velocity = transform.forward * speed_;
                break;
            case SpellType.kWater:
                speed_ = 15.0f;
                projectileObj = Instantiate(waterPrefab_, transform.position, Quaternion.identity) as GameObject;
                projectileObj.GetComponent<Rigidbody>().velocity = transform.forward * speed_;
                break;
        }
    }
}
