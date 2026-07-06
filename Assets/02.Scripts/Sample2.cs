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
        if (Input.GetKey(KeyCode.D)) //this.rbody.linearVelocityX < this.LMaxSpeed)
        {
            rbody.AddTorque(-torquePower);
        }

        if (Input.GetKey(KeyCode.A)) //&& this.rbody.linearVelocityX < this.RMaxSpeed)
        {
            rbody.AddTorque(torquePower);
        }

        if (Input.GetKeyDown    (KeyCode.Space))
        {
            this.rbody.AddForce(transform.up * JumpPower);
        }
    }
}
