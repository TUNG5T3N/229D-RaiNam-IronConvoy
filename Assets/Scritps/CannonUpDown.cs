using UnityEngine;
using UnityEngine.InputSystem;

public class CannonUpDown : MonoBehaviour
{
    public float cannonRotateSpeed = 120f;

    Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        CannonRotate();
    }

    void CannonRotate()
    {
       

        float j = 0;
        if (Keyboard.current != null)
        {
            j = (Keyboard.current.upArrowKey.isPressed ? 1f : 0) - (Keyboard.current.downArrowKey.isPressed ? 1f : 0);
        }

        transform.Rotate(Vector3.right * j * cannonRotateSpeed * Time.deltaTime);
    }
}
