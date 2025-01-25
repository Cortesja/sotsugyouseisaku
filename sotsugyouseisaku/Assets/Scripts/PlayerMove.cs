using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Assertions;

[RequireComponent (typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed_ = 1f;
    private Rigidbody rb_;
    private Vector2 moveInput_;
    [SerializeField]
    private Cursor cursor_;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            Debug.Log("colliding....");
            collision.gameObject.SetActive(false);
        }
    }

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

        bool isGet =
            Camera.main.TryGetComponent<Cursor>(out cursor_);
        Assert.IsTrue(isGet, "component失敗");
    }

    // Update is called once per frame
    void Update()
    {
        rb_.velocity = Vector3.zero;
        if (!cursor_.GetIsHit()) { return; }
        RaycastHit raycastHit = cursor_.GetRaycastHit();
        Vector3 lookAt = raycastHit.point;

        lookAt.y = transform.position.y;

        transform.LookAt(lookAt);

        // Rotate 180 degrees around the Y-axis
        //ブレンダーのモデルの向きは後ろ向きだったので
        Vector3 testAngle = new Vector3(0f, 180f, 0f);
        transform.rotation *= Quaternion.Euler(testAngle);
    }
}
