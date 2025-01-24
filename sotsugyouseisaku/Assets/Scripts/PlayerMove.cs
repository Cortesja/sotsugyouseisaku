using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent (typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed_ = 1f;
    private Rigidbody rb_;
    private Vector2 moveInput_;
    [SerializeField]
    private Cursor cursor_;

    public void OnMove(InputValue value)
    {
       moveInput_ = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector3 input;
        input = new Vector3(
            moveInput_.x,
            0,
            moveInput_.y);
        if(input.sqrMagnitude == 0) { return; }

        rb_.MovePosition(
            transform.position + input * moveSpeed_ * Time.deltaTime);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb_ = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb_.angularVelocity = Vector3.zero;
    }
}
