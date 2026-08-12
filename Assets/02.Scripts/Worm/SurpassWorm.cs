using UnityEngine;

public class SurpassWorm : MonoBehaviour
{
   float surpassHeight = 1.0f;
   float wormPos;
   Rigidbody2D rBody;

    private void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        wormPos = this.transform.position.y;

        if (this.rBody.linearVelocityX <= 1)
        {
            wormPos += 1;
        }
    }
}
