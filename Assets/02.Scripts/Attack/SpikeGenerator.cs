using UnityEngine;

public class SpikeGenerator : MonoBehaviour
{
    public GameObject apple;
    public GameObject firePoint;
    public GameObject spikePrefab;
    public float senseDist = 5;

    private void Update()
    {
        Vector3 applePos = apple.transform.position;
        float applePosX = applePos.x;
        float wormPosX = this.transform.position.x;

        float distance = Mathf.Abs(wormPosX - applePosX);

        if (distance < senseDist)
        {
            GameObject wormSpike = Instantiate(spikePrefab, firePoint.transform.position, transform.rotation);

            SpikeController spikeController = wormSpike.GetComponent<SpikeController>();

            spikeController.SetDirection(firePoint.transform.up);
        }
    }
}
