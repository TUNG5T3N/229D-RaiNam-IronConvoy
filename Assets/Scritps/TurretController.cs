using UnityEngine;
using UnityEngine.InputSystem;

public class TurretController : MonoBehaviour
{
    public float turretRotateSpeed = 120f;

    Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        TurretRotate();
    }

    void TurretRotate()
    {
        //Left / Right rotation (<-/->)
        //float h = Input.GetAxis("Horizontal");
        float h = 0;
        if (Keyboard.current != null)
        {
            h = (Keyboard.current.rightArrowKey.isPressed ? 1f : 0) - (Keyboard.current.leftArrowKey.isPressed ? 1f : 0);
        }

        transform.Rotate(Vector3.up * h * turretRotateSpeed * Time.deltaTime);

        
    }
}
