using UnityEngine;

public class AppleContorller : MonoBehaviour
{
    Rigidbody2D rbody;
    float torquePower = 1.0f;
    public float jumpPower = 1.0f;

    private void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rbody.AddTorque(-torquePower);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rbody.AddTorque(torquePower);
        }

        if (Mathf.Abs(rbody.angularVelocity) > 300f)
        {
            rbody.angularVelocity = Mathf.Sign(rbody.angularVelocity) * 300f;
        }

        if (Input.GetKey(KeyCode.Space) && this.rbody.linearVelocityY == 0)
        {
            rbody.AddForce(Vector2.up * jumpPower);
        }
    }
}
