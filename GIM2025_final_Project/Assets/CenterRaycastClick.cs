using UnityEngine;

public class GameStageManager : MonoBehaviour
{
    public int progressStage = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // 화면 중앙에서 정면으로 Ray 발사
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f))
            {
                GameObject clicked = hit.collider.gameObject;

                // ? 클릭한 오브젝트 이름 출력
                Debug.Log("? 클릭한 오브젝트: " + clicked.name);

                // ? 단계 0: Radio 클릭
                if (progressStage == 0 && clicked.CompareTag("Radio"))
                {
                    Debug.Log("? 라디오를 켰습니다!");
                    // 여기에 라디오 관련 이벤트 추가 가능
                    progressStage = 1;
                }

                // ? 단계 1: MainNPC 클릭
                else if (progressStage == 1 && clicked.CompareTag("MainNPC"))
                {
                    Debug.Log("? 메인 NPC와 대화합니다!");
                    // 여기에 NPC 관련 이벤트 추가 가능
                    progressStage = 2;
                }

                // ? 나머지 오브젝트 클릭 시: 이름만 출력
                else
                {
                    Debug.Log("?? 아직 상호작용할 수 없는 오브젝트입니다.");
                }
            }
        }
    }
}
