using UnityEngine;
using UnityEngine.InputSystem;

public class RayShooter : MonoBehaviour
{
    [SerializeField] private Transform shootPos;
    [SerializeField] private float rayLength = 5.5f;
    public int pointPerKill = 10;
    public PointSystem pointSystem;

    void Update()
    {
        ShootRay();
    }
    [SerializeField] private GameObject shootVFX;
    [SerializeField] private GameObject hitVFX;
    [SerializeField] private int damage = 25;
    void ShootRay()
    {
        RaycastHit hit;

        Debug.DrawRay(shootPos.position, transform.forward * rayLength, Color.green);

        if (Physics.Raycast(shootPos.position, transform.forward, out hit, rayLength))
        {
            Debug.DrawRay(shootPos.position, transform.forward * hit.distance, Color.red);

            Debug.Log($"Ray hits: {hit.collider.name}");

            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                /*var shootVfx = Instantiate(shootVFX, shootPos.position, shootPos.rotation, shootPos);
                var hitVfx = Instantiate(hitVFX, hit.point, Quaternion.identity);

                Destroy(shootVfx, 1.5f);
                Destroy(hitVfx, 1.5f);*/

                if (hit.collider.CompareTag("Enemy"))
                {
                    Enemy enemy = hit.collider.GetComponent<Enemy>();
                    if (enemy !=null)
                    {
                        enemy.TakeDamage(damage);
                        if (enemy.isDead())
                        {
                            pointSystem.AddPoints(pointPerKill);
                        }
                    }
                }


                /*if (hit.collider.CompareTag("Obstacle"))
                {
                    var rb = hit.collider.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.AddTorque(0, 500, 0);
                    }
                }*/
            }
        }
    }
}
