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
        // 매테리얼 컴포넌트 캐싱.
        material = GetComponent<Renderer>().material;
        // 카메라의 이전 프레임 위치.
        prevCamPos = Camera.main.transform.position;
        // apple 오브젝트 캐싱.
        apple = GameObject.Find("Apple");
    }

    void Update()
    {
        // 카메라가 움직이고 있는 방향.
        Vector2 camDir; 

        // 지금 카메라 위치에서 이전 카메라 위치를 뺀다.
        camDir = (Vector2)Camera.main.transform.position - prevCamPos;
        // y좌표는 고정.
        camDir.y = 0;

        // camDir을 방향으로 한다.
        MoveOffset(camDir);
        // 맨 마지막에 처리하여 과거의 위치도록 한다.
        prevCamPos = Camera.main.transform.position;
    }

    void MoveOffset(Vector2 direction)
    {
        // 방향 쪽으로 배경이 속도의 따라 움직인다.
        material.mainTextureOffset += direction * offsetSpeed;
    }

    private void LateUpdate()
    {   
        // pos는 사과의 위치.
        Vector3 pos = apple.transform.position;
        // 배경의 높이.
        pos.y = backgroundPosY;
        // z좌표는 고정.
        pos.z = this.transform.position.z;

        // 배경화면의 위치는 사과의 위치.
        transform.position = pos;
    }
}
