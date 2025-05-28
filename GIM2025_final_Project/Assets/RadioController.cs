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
        Debug.Log("Radio clicked! NPCStage�� �Ѿ�� ��...");
        News1.SetActive(true);               // ? ���� ������Ʈ �ѱ�
        StartCoroutine(HandleRadioClickWithDelay());
        
    }
    private IEnumerator HandleRadioClickWithDelay()
    {
        yield return new WaitForSeconds(3f); // ? 3�� ���
        radioStart.Invoke();
        StartCoroutine(ChangeStageAfterDelay(7f)); // ? ���� �ܰ� �̵� ��� ����
    }

    private IEnumerator ChangeStageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (gameStageManager != null)
        {
            gameStageManager.currentStage = GameStageManager.GameStage.TalkingWithMainNPC1;
            //whiteNoise.SetActive(false);
            eventFinish.Invoke();
            Debug.Log("7�� ��� - NPCStage�� �����");
        }
        else
        {
            Debug.LogWarning("GameStageManager�� ������� �ʾҽ��ϴ�.");
        }
    }
}
