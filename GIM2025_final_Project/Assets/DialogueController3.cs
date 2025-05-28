using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueController3 : MonoBehaviour
{
    [Header("?? ��ǳ�� ������Ʈ��")]
    public List<GameObject> dialogueList;

    [Header("?? �� ��ǳ�� ǥ�� �ð�")]
    public float displayInterval = 5.0f;

    [Header("? �������� �Ŵ���")]
    [Tooltip("GameStageManager�� Drag & Drop �ϼ���.")]
    public GameStageManager gameStageManager;

    [Header("? �̺�Ʈ �� �������� ��ȯ ������")]
    [Tooltip("eventFinish ���� �� �������� ������� ��ٸ� �ð� (��)")]
    public float stageChangeDelay = 3.0f;

    private Coroutine dialogueCoroutine;
    public UnityEvent eventFinish;
    public UnityEvent eventFinish2;

    [Header("���ϴ� ĳ���� �ִϸ�����")]
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

        // �̺�Ʈ ȣ��
        eventFinish.Invoke();

        // ������ �ð���ŭ ���
        yield return new WaitForSeconds(stageChangeDelay);
        eventFinish2.Invoke();

        // �������� ��ȯ
        if (gameStageManager != null)
        {
            gameStageManager.currentStage = GameStageManager.GameStage.GoToBridge;
            Debug.Log("? ��ȭ ���� �� ���������� GoToBridge�� ��ȯ��");
        }
        else
        {
            Debug.LogWarning("?? GameStageManager�� ������� �ʾҽ��ϴ�.");
        }
    }
}
