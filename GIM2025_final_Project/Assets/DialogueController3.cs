using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueController3 : MonoBehaviour
{
    [Header("?? 말풍선 오브젝트들")]
    public List<GameObject> dialogueList;

    [Header("?? 각 말풍선 표시 시간")]
    public float displayInterval = 5.0f;

    [Header("? 스테이지 매니저")]
    [Tooltip("GameStageManager를 Drag & Drop 하세요.")]
    public GameStageManager gameStageManager;

    [Header("? 이벤트 후 스테이지 전환 딜레이")]
    [Tooltip("eventFinish 실행 후 스테이지 변경까지 기다릴 시간 (초)")]
    public float stageChangeDelay = 3.0f;

    private Coroutine dialogueCoroutine;
    public UnityEvent eventFinish;
    public UnityEvent eventFinish2;

    [Header("말하는 캐릭터 애니메이터")]
    public Animator animator;
    void Awake()
    {
        foreach (GameObject dialogue in dialogueList)
        {
            if (dialogue != null)
                dialogue.SetActive(false);
        }
    }

    public void StartDialogue()
    {
        if (dialogueCoroutine != null)
        {
            StopCoroutine(dialogueCoroutine);
        }

        dialogueCoroutine = StartCoroutine(PlayDialogueSequence());
    }

    private IEnumerator PlayDialogueSequence()
    {
        animator.SetBool("Talking", true);
        foreach (GameObject dialogue in dialogueList)
        {
            if (dialogue != null)
            {
                dialogue.SetActive(true);
                yield return new WaitForSeconds(displayInterval);
                dialogue.SetActive(false);
            }
        }
        animator.SetBool("Talking", false);

        // 이벤트 호출
        eventFinish.Invoke();

        // 설정된 시간만큼 대기
        yield return new WaitForSeconds(stageChangeDelay);
        eventFinish2.Invoke();

        // 스테이지 전환
        if (gameStageManager != null)
        {
            gameStageManager.currentStage = GameStageManager.GameStage.GoToBridge;
            Debug.Log("? 대화 종료 후 스테이지를 GoToBridge로 전환됨");
        }
        else
        {
            Debug.LogWarning("?? GameStageManager가 연결되지 않았습니다.");
        }
    }
}
