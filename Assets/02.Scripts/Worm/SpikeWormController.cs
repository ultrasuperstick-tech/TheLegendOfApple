using UnityEngine;

public class SpikeWormController : MonoBehaviour
{
    public GameObject apple;

    private void Update()
    {
        Vector3 applePos = apple.transform.position;
        float applePosX = applePos.x;
        float wormPosX = this.transform.position.x;

        float distance = Mathf.Abs(wormPosX - applePosX);

        if ((applePosX - wormPosX) > 0)
        {
            //왼쪽 보기.
        }
        else
        {
            //오른쪽 보기.
        }
    }
}
