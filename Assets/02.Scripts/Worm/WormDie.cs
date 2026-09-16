using UnityEngine;

public class WormDie : MonoBehaviour
{
    GameObject apple;
    GameObject parentGameObject;
    Transform parentTransform;
    Rigidbody2D parentRBody;
    public float jumpPower = 100;
    public float distoryTime = 5;
    public GameObject spikeEffect;

    private void Awake()
    {
        apple = GameObject.Find("Apple");
        parentTransform = transform.parent;
        parentGameObject = parentTransform.gameObject;
        parentRBody = parentGameObject.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == apple)
        {
            parentRBody.freezeRotation = false;
            parentRBody.AddTorque(jumpPower * 10);
            Instantiate(spikeEffect, transform.position, transform.rotation);
            parentRBody.AddForceY(jumpPower, ForceMode2D.Impulse);
            parentGameObject.GetComponent<SurpassWorm>().enabled = false;
            parentGameObject.GetComponent<Collider2D>().enabled = false;
            gameObject.GetComponent<Collider2D>().enabled = false;

            Destroy(parentGameObject, distoryTime);
            Destroy(gameObject, distoryTime);
        }
    }
}
