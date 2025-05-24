using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class RadioController : MonoBehaviour
{
    public GameStageManager gameStageManager;
    public GameObject whiteNoise;
    public GameObject News1;
    public UnityEvent eventFinish;

    void Start()
    {
        whiteNoise.SetActive(true);
        News1.SetActive(false);
    }
    public void OnRadioClicked()
    {
        Debug.Log("Radio clicked! NPCStage로 넘어가는 중...");
        StartCoroutine(ChangeStageAfterDelay(7f));
        News1.SetActive(true);
    }

    private IEnumerator ChangeStageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (gameStageManager != null)
        {
            gameStageManager.currentStage = GameStageManager.GameStage.TalkingWithMainNPC1;
            whiteNoise.SetActive(false);
            eventFinish.Invoke();
            Debug.Log("7초 경과 - NPCStage로 변경됨");
        }
        else
        {
            Debug.LogWarning("GameStageManager가 연결되지 않았습니다.");
        }
    }
}
