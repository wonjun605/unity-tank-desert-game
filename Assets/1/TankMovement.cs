using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 120f;

    private Rigidbody tankRigidbody;
    private float moveInput;
    private float turnInput;

    void Awake()
    {
        tankRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // W/S 또는 위/아래 방향키 입력
        moveInput = Input.GetAxisRaw("Vertical");

        // A/D 또는 좌/우 방향키 입력
        turnInput = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        // 탱크가 바라보는 방향으로 앞뒤 이동
        Vector3 movement = transform.forward * moveInput * moveSpeed * Time.fixedDeltaTime;
        tankRigidbody.MovePosition(tankRigidbody.position + movement);

        // Y축 기준으로 좌우 회전
        Quaternion turn = Quaternion.Euler(
            0f,
            turnInput * turnSpeed * Time.fixedDeltaTime,
            0f
        );

        tankRigidbody.MoveRotation(tankRigidbody.rotation * turn);
    }
}