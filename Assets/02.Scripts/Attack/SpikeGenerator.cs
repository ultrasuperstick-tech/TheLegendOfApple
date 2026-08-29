using UnityEngine;

public class SpikeGenerator : MonoBehaviour
{
    // 게임 오브젝트들.
    public GameObject apple;
    public GameObject firePoint;
    public GameObject spikePrefab;
    // 감지 거리.
    public float senseDist = 10;    
    // 가지 발사 시간 재는 타이머.
    float spikeTimer = 0;
    // 가시 발사 쿨타임.
    public float spikecooltime = 3;
    // 공격할 수 있는지 없는지 판단.
    bool canAttck;

    private void Start()
    {
        // apple 게임 오브젝트 캐싱.
        apple = GameObject.Find("Apple");
        // 공격 기능 비활성화.
        canAttck = false;
        // 가시발사 타이머 초기화.
        spikeTimer = 0;
    }

    private void Update()
    {
        // 사과의 위치.
        Vector3 applePos = apple.transform.position;
        // 애벌래의 위치.
        Vector3 wormPos = transform.position;
        // 사과의 X 좌표 위치.
        float applePosX = applePos.x;
        // 애벌래의 X 좌표 위치.
        float wormPosX = wormPos.x;
        
        // 사과와 애벌래의 거리.
        float distance = Mathf.Abs(wormPosX - applePosX);

        if (canAttck == true)
        {
            // canAttck이 true면 쿨타임을 시작한다.
            spikeTimer += Time.deltaTime;
        }

        // 만약 감지거리(senseDist)안에 들어오면.
        if (distance < senseDist)
        {
            // 쿨타임을 시작하고.
            canAttck = true;

            // 만약 쿨타임이 다돌면,
            if (spikeTimer >= spikecooltime)
            {
                //사과와 애벌래의 방향
                Vector3 direction = applePos - wormPos;

                // 가시를 소환한다.
                GameObject wormSpike = Instantiate(spikePrefab, firePoint.transform.position, transform.rotation);
                //스파이크 컨트롤러 컴포넌트 캐싱.
                SpikeController spikeController = wormSpike.GetComponent<SpikeController>();
                // 스파이크 컨트롤러에 방향을 정해준다.
                spikeController.SetDirection(direction);

                // 쿨타임 초기화.
                spikeTimer = 0;
                // 공격 비활성화
                canAttck = false;
            }
        }
    }
}
