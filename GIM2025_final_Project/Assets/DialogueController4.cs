using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class DialogueController4 : MonoBehaviour
{
    [Header("?? ��ǳ�� ������Ʈ��")]
    public List<GameObject> dialogueList;

    [Header("?? �� ��ǳ�� ǥ�� �ð�")]
    public float displayInterval = 5.0f;



    private Coroutine dialogueCoroutine;
    public UnityEvent eventFinish;
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

        // ��ǳ�� ǥ�ð� ���� �� �������� ����
        eventFinish.Invoke();

    }
}
