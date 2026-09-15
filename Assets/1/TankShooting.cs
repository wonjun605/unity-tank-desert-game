using UnityEngine;

public class TankShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float launchForce = 20f;
    public float cooldown = 0.4f;

    private float nextFireTime;

    void Update()
    {
        // Space를 누르고 있고, 다음 발사가 가능한 시간일 때
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
        {
            Fire();

            // 다음 발사 가능 시간 설정
            nextFireTime = Time.time + cooldown;
        }
    }

    void Fire()
    {
        // FirePoint 위치와 방향으로 Bullet Prefab 복제
        GameObject bullet = Instantiate(
            bulletPrefab,
            firePoint.position,
            firePoint.rotation
        );

        // 복제한 총알의 Rigidbody를 찾아 앞으로 힘을 줌
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

        bulletRigidbody.AddForce(
            firePoint.forward * launchForce,
            ForceMode.VelocityChange
        );

        // 3초 뒤 총알 삭제
        Destroy(bullet, 3f);
    }
}