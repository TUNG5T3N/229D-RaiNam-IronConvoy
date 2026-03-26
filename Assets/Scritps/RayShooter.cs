using UnityEngine;
using UnityEngine.InputSystem;

public class RayShooter : MonoBehaviour
{
    [SerializeField] private Transform shootPos;
    [SerializeField] private float rayLength = 5.5f;

    void Update()
    {
        ShootRay();
    }
    [SerializeField] private GameObject shootVFX;
    [SerializeField] private GameObject hitVFX;
    [SerializeField] private int damage = 25;
    void ShootRay()
    {
        // เอาไว้เก็บ เมื่อ Ray กระทบกับวัตถุ
        RaycastHit hit;

        // ยิง Ray ที่เป็น Visual เท่านั้น ไม่มีการทำงานจริง
        Debug.DrawRay(shootPos.position, transform.forward * rayLength, Color.green);

        // ยิง Ray (ล่องหน) เพื่อเช็คว่ากระทบวัตถุอะไรมั้ย และ return ข้อมูลออกมาใส่ตัวแปร hit
        if (Physics.Raycast(shootPos.position, transform.forward, out hit, rayLength))
        {
            // ยิง Ray Visual เป็นสีแดงมีความยาวถึงแค่จุดที่ Ray กระทบวัตถุ
            Debug.DrawRay(shootPos.position, transform.forward * hit.distance, Color.red);

            // รายงานชื่อของวัตถุที่มี collider เมื่อ Ray ยิงโดน
            Debug.Log($"Ray hits: {hit.collider.name}");

            if (Mouse.current.rightButton.wasPressedThisFrame)
            {
                // เสก VFX ที่จุดยิง
                var shootVfx = Instantiate(shootVFX, shootPos.position, shootPos.rotation, shootPos);
                // เสก VFX ที่จุดยิงโดนวัตถุ
                var hitVfx = Instantiate(hitVFX, hit.point, Quaternion.identity);

                // ทำลาย VFX ที่เสกตามเวลาที่กำหนด
                Destroy(shootVfx, 1.5f);
                Destroy(hitVfx, 1.5f);

                /*if (hit.collider.CompareTag("Enemy"))
                {
                    Enemy enemy = hit.collider.GetComponent<Enemy>();
                    if (enemy !=null)
                    {
                        enemy.TakeDamage(damage);
                    }
                }*/

                // เช็คว่าโดน tag "Obstacle" มั้ย
                // ดึง <Rigidbody> ใส่ตัวแปร rb
                // เช็ค rb != null
                // rb.AddTorque หมุนแค่แกน Y เท่าที่ต้องการ

                if (hit.collider.CompareTag("Obstacle"))
                {
                    var rb = hit.collider.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.AddTorque(0, 500, 0);
                    }
                }
            }
        }
    }
}
