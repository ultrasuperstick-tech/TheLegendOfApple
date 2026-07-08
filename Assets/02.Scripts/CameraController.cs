using UnityEngine;

public class CameraController : MonoBehaviour
{

    private void LateUpdate()
    {
        //이 오브젝트의 좌표를 얻는다
        Vector3 pos = this.transform.position;
        
        // z좌표를 -10으로 둔다
        pos.z = -10;
        
        //키메라가 이 오브젝트의 위치로 이동한다
        Camera.main.gameObject.transform.position = pos;
    }
}
