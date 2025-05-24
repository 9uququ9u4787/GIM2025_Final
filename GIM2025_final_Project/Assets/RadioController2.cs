using System.Collections;
using UnityEngine;
using UnityEngine.Events;
public class RadioController2 : MonoBehaviour
{
    public GameStageManager gameStageManager;
    public GameObject News2;
    public UnityEvent eventFinish;

    void Start()
    {
        News2.SetActive(false);
    }
    public void OnRadioClicked()
    {
        Debug.Log("Radio clicked! NPCStage�� �Ѿ�� ��...");
        StartCoroutine(ChangeStageAfterDelay(7f));
        News2.SetActive(true);
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
