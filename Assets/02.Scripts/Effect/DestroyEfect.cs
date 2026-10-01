using UnityEngine;

public class DestroyEfect : MonoBehaviour
{

    private void Start()
    {
        // 이팩트가 끝나고 삭제시킨다
        Destroy(gameObject, 5f);
    }
}
