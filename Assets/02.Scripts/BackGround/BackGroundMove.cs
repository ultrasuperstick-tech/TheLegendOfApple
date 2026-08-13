using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
    [SerializeField]
    private Transform cameraTransform;

    private Vector3 cameraStartPosition;
    private float distance;

    private Material[] materials;
    private float[] layerMoveSpeed;

    [SerializeField][Range(0.01f, 1.0f)]
    private float[] parallaxSpeed;

    private void Awake()
    {
        cameraStartPosition = cameraTransform.position;

        int backgroundCount = transform.childCount;
        GameObject[] background = new GameObject[backgroundCount];

        materials = new Material[backgroundCount];
        layerMoveSpeed = new float[backgroundCount];

        for (int i = 0; i < backgroundCount; ++i)
        {
            background[i] = transform.GetChild(i).gameObject;
            materials[i] = background[i].GetComponent<Renderer>().material;
        }

        
    }
}
