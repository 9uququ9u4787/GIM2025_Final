using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueController2 : MonoBehaviour
{
    [Header("?? ��ǳ�� ������Ʈ��")]
    public List<GameObject> dialogueList;

    [Header("?? �� ��ǳ�� ǥ�� �ð�")]
    public float displayInterval = 5.0f;

    [Header("? �������� �Ŵ���")]
    [Tooltip("GameStageManager�� Drag & Drop �ϼ���.")]
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

        // ��ǳ�� ǥ�ð� ���� �� �������� ����
        eventFinish.Invoke();
        if (gameStageManager != null)
        {
            gameStageManager.currentStage = GameStageManager.GameStage.GoToPostOffice;
            Debug.Log("��ȭ ���� �� ���������� RadioAndFog�� ��ȯ");
        }
        else
        {
            Debug.LogWarning("GameStageManager�� ������� �ʾҽ��ϴ�.");
        }
    }
}
