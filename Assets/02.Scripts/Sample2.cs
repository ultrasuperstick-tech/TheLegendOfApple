using UnityEngine;
using UnityEngine.InputSystem;

public class Sample2 : MonoBehaviour
{
    public Rigidbody2D rbody;
    public float torquePower = 1f;
    public float JumpPower = 1f;
    public float LMaxSpeed = -2f;
    public float RMaxSpeed = 2f;


    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.dKey.isPressed) //this.rbody.linearVelocityX < this.LMaxSpeed)
        {
            rbody.AddTorque(-torquePower);
        }

        if (Keyboard.current.aKey.isPressed) //&& this.rbody.linearVelocityX < this.RMaxSpeed)
        {
            rbody.AddTorque(torquePower);
        }

        if (Keyboard.current.spaceKey.isPressed)
        {
            this.rbody.AddForce(transform.up * JumpPower);
        }
    }
}
