using UnityEngine;
using UnityEngine.InputSystem;

public class TankMoveNewInput : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float rotateSpeed = 30f;

    float move;
    float rotate;
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Mathf.Abs(move) > 0.1f || Mathf.Abs(rotate) > 0.1f)
        {
            Move();
            Rotate();
        }
    }

    void OnMove(InputValue value)
    {
        //Debug.Log("Move value : " + value.Get<float>());
        move = value.Get<float>();
    }
    void OnRotate(InputValue value)
    {
        //Debug.Log("Rotate value : " + value.Get<float>());
        rotate = value.Get<float>();
    }

    void Move()
    {
        Vector3 moveDir = transform.forward * move * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + moveDir);
    }

    void Rotate()
    {
        float rotSpeed = rotate * rotateSpeed * Time.deltaTime;
        rb.rotation = Quaternion.Euler(0f, rotSpeed, 0f) * rb.rotation;
    }
}
