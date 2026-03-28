using UnityEngine;
using UnityEngine.InputSystem;

public class TankMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 120f;
    public float jumpForce = 12f;

    Rigidbody rb;
    bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Rotate();
    }

    void FixedUpdate()
    {
        Move();
        Boost();
    }

    void Move()
    {
        float v = 0;
        if (Keyboard.current != null)
        {
            v = (Keyboard.current.wKey.isPressed ? 1f : 0) - (Keyboard.current.sKey.isPressed ? 1f :0);
        }
        
        Vector3 forwardMove = transform.forward * v * moveSpeed;
        rb.linearVelocity = new Vector3(forwardMove.x, rb.linearVelocity.y, forwardMove.z);
    }

    void Rotate()
    {
        float h = 0;
        if (Keyboard.current != null)
        {
            h = (Keyboard.current.dKey.isPressed ? 1f : 0) - (Keyboard.current.aKey.isPressed ? 1f :0);
        }

        transform.Rotate(Vector3.up * h * rotateSpeed * Time.deltaTime);
    }

    void Boost()
    {
        if(Keyboard.current.leftShiftKey.wasPressedThisFrame)
        {
            moveSpeed *= 2;
        }
        if (Keyboard.current.leftShiftKey.wasReleasedThisFrame)
        {
            moveSpeed /= 2;
        }
    }

    void Unstuck()
    {
        if(Keyboard.current.rKey.isPressed)
        { 
                
        }
    }

}
