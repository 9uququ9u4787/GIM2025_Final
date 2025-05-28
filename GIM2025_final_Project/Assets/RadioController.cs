using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class RadioController : MonoBehaviour
{
    public GameStageManager gameStageManager;
    public GameObject whiteNoise;
    public GameObject News1;
    public UnityEvent eventFinish;
    public UnityEvent radioStart;

    void Start()
    {
        whiteNoise.SetActive(true);
        News1.SetActive(false);
    }
    public void OnRadioClicked()
    {
        Debug.Log("Radio clicked! NPCStage로 넘어가는 중...");
        News1.SetActive(true);               // ? 뉴스 오브젝트 켜기
        StartCoroutine(HandleRadioClickWithDelay());
        
    }
    private IEnumerator HandleRadioClickWithDelay()
    {
        yield return new WaitForSeconds(3f); // ? 3초 대기
        radioStart.Invoke();
        StartCoroutine(ChangeStageAfterDelay(7f)); // ? 다음 단계 이동 대기 시작
    }

    private IEnumerator ChangeStageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (gameStageManager != null)
        {
            gameStageManager.currentStage = GameStageManager.GameStage.TalkingWithMainNPC1;
            //whiteNoise.SetActive(false);
            eventFinish.Invoke();
            Debug.Log("7초 경과 - NPCStage로 변경됨");
        }
        else
        {
            Debug.LogWarning("GameStageManager가 연결되지 않았습니다.");
        }
    }
}
