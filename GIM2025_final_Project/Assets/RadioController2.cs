using System.Collections;
using UnityEngine;
using UnityEngine.Events;
public class RadioController2 : MonoBehaviour
{
    public GameStageManager gameStageManager;
    public GameObject News2;
    public UnityEvent eventFinish;
    public UnityEvent radioStart;

    void Start()
    {
        News2.SetActive(false);
    }
    public void OnRadioClicked()
    {
        Debug.Log("Radio clicked! NPCStage�� �Ѿ�� ��...");
        News2.SetActive(true);               // ? ���� ������Ʈ �ѱ�
        StartCoroutine(HandleRadioClickWithDelay());
    }

    private IEnumerator HandleRadioClickWithDelay()
    {
        yield return new WaitForSeconds(4f); // ? 3�� ���
        radioStart.Invoke();
        
        StartCoroutine(ChangeStageAfterDelay(24.5f)); // ? ���� �ܰ� �̵� ��� ����
    }

    private IEnumerator ChangeStageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (gameStageManager != null)
        {
            gameStageManager.currentStage = GameStageManager.GameStage.TalkingWithMainNPC2;
            News2.SetActive(false);
            eventFinish.Invoke();
            Debug.Log("7�� ��� - NPCStage�� �����");
        }
        else
        {
            Debug.LogWarning("GameStageManager�� ������� �ʾҽ��ϴ�.");
        }
    }
}
