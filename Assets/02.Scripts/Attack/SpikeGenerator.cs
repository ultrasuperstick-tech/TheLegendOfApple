using UnityEngine;

public class SpikeGenerator : MonoBehaviour
{
    public GameObject apple;
    public GameObject firePoint;
    public GameObject spikePrefab;
    public float senseDist = 5;
    public float spikeTimer = 0;
    public float spikecooltime = 3;
    bool canAttck;

    private void Start()
    {
        apple = GameObject.Find("Apple");
        canAttck = false;
        spikeTimer = 0;
    }

    private void Update()
    {
        Vector3 applePos = apple.transform.position;
        Vector3 wormPos = transform.position;
        float applePosX = applePos.x;
        float wormPosX = wormPos.x;

        float distance = Mathf.Abs(wormPosX - applePosX);

        if (canAttck == true)
        {
            spikeTimer += Time.deltaTime;
        }

        if (distance < senseDist)
        {
            canAttck = true;

            if (spikeTimer >= spikecooltime)
            {
                Vector3 direction = applePos - wormPos;

                GameObject wormSpike = Instantiate(spikePrefab, firePoint.transform.position, transform.rotation);

                SpikeController spikeController = wormSpike.GetComponent<SpikeController>();

                spikeController.SetDirection(direction);

                spikeTimer = 0;
                canAttck = false;
            }
        }
    }
}
