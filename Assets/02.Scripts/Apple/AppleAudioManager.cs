using UnityEngine;

public class AppleAudioManager : MonoBehaviour
{
    AudioSource audioSource;
    public GameObject apple;
    public AudioClip landingSound;
    Rigidbody2D rBody;
    public bool canLand;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        apple = GameObject.Find("Apple");
        rBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        canLand = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && canLand == true)
        {
            foreach (ContactPoint2D contact in collision.contacts)
            {
                if (contact.normal.y > 0.5f)
                {
                    Debug.Log("¹Ù´Ú ÂøÁö");
                    audioSource.PlayOneShot(landingSound);
                    canLand = false;
                }
            }
        }
    }
}
