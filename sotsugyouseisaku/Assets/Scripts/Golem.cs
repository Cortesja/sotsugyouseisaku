using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]

public class Golem : MonoBehaviour
{
    [SerializeField] float speed_ = 2.0f;
    private Rigidbody rb_;
    [SerializeField] Transform player_;
    [SerializeField] float stopDistance_ = 1.0f;

    void  GolemMovement()
    {
        if (player_ != null)
        {
            float distance = Vector3.Distance(player_.transform.position, transform.position);

            if (distance > stopDistance_)
            {
                Vector3 direction = (player_.transform.position - transform.position).normalized;

                transform.position += direction * speed_ * Time.deltaTime;
                Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, direction);
                targetRotation.y = 0;
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speed_);
            }
        }   
    }

    // Start is called before the first frame update
    void Start()
    {
       rb_ = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GolemMovement();
    }
}
