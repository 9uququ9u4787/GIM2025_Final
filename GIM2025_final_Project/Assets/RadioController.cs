using System.Collections;
using UnityEngine;

public class RadioController : MonoBehaviour
{
    public GameStageManager gameStageManager;
    public GameObject whiteNoise;
    public GameObject News1;

    void Start()
    {
        whiteNoise.SetActive(true);
        News1.SetActive(false);
    }
    public void OnRadioClicked()
    {
        Debug.Log("Radio clicked! NPCStage�� �Ѿ�� ��...");
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
            Debug.Log("7�� ��� - NPCStage�� �����");
        }
        else
        {
            Debug.LogWarning("GameStageManager�� ������� �ʾҽ��ϴ�.");
        }
    }
}
