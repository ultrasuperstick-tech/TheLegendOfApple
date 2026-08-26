using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BackgroundCtrl : MonoBehaviour
{
    public float offsetSpeed = 0.05f;
    public float backgroundPosY;
    Material material;
    GameObject apple;

    Vector2 prevCamPos; // 이전 프레임에서 카메라의 위치.
    void Start()
    {
        material = GetComponent<Renderer>().material;
        prevCamPos = Camera.main.transform.position;
        apple = GameObject.Find("Apple");
    }

    void Update()
    {

        Vector2 camDir; // 카메라가 움직이고 있는 방향.

        camDir = (Vector2)Camera.main.transform.position - prevCamPos;
        camDir.y = 0;

        MoveOffset(camDir);
        prevCamPos = Camera.main.transform.position;
    }

    void MoveOffset(Vector2 direction)
    {
        material.mainTextureOffset += direction * offsetSpeed;
    }

    private void LateUpdate()
    {
        Vector3 pos = apple.transform.position;
        pos.y = backgroundPosY;
        pos.z = this.transform.position.z;

        transform.position = pos;
    }
}
