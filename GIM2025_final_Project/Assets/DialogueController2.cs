using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueController2 : MonoBehaviour
{
    [Header("?? 말풍선 오브젝트들")]
    public List<GameObject> dialogueList;

    [Header("?? 각 말풍선 표시 시간")]
    public float displayInterval = 5.0f;

    [Header("? 스테이지 매니저")]
    [Tooltip("GameStageManager를 Drag & Drop 하세요.")]
    public GameStageManager gameStageManager;

    private Coroutine dialogueCoroutine;
    public UnityEvent eventFinish;

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
        foreach (GameObject dialogue in dialogueList)
        {
            if (dialogue != null)
            {
                dialogue.SetActive(true);
                yield return new WaitForSeconds(displayInterval);
                dialogue.SetActive(false);
            }
        }

        // 말풍선 표시가 끝난 뒤 스테이지 변경
        eventFinish.Invoke();
        if (gameStageManager != null)
        {
            gameStageManager.currentStage = GameStageManager.GameStage.GoToPostOffice;
            Debug.Log("대화 종료 → 스테이지를 RadioAndFog로 전환");
        }
        else
        {
            Debug.LogWarning("GameStageManager가 연결되지 않았습니다.");
        }
    }
}
