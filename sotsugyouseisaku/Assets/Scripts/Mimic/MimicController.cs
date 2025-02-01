using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MimicController : MonoBehaviour
{
    [SerializeField, Header("angle")]
    private Vector3 startAngle_;
    [SerializeField] private Vector3 endAngle_;
    [SerializeField] private float motionTime_ = 1.0f;
    float angleTime_ = 0.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles = AngleLerp();
    }

    public void IdolMove()
    {
        AngleLerp();
    }

    // 角度の線形補間
    Vector3 AngleLerp()
    {
        angleTime_ += Time.deltaTime;// 経過時間
        float param = Mathf.Sin(2.0f * Mathf.PI * angleTime_ / motionTime_); // 角度を計算
        Vector3 theta = Vector3.Lerp(startAngle_, endAngle_, (param + 1.0f) / 2.0f); // 線形補間
        return theta;
    }
}
