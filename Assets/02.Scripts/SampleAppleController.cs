using UnityEngine;
using UnityEngine.InputSystem;

public class SampleAppleController : MonoBehaviour
{
    public Rigidbody2D rbody;
    public float speed = 1f;

    void Update()
    {
        if (Keyboard.current.dKey.isPressed)
        {
            this.rbody.AddForce(transform.right * this.speed);
        }

        if (Keyboard.current.aKey.isPressed)
        {
            this.rbody.AddForce(-transform.right * this.speed);
        }
    }
}
