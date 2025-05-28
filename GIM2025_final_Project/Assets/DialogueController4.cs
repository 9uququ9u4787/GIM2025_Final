using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class DialogueController4 : MonoBehaviour
{
    [Header("?? 말풍선 오브젝트들")]
    public List<GameObject> dialogueList;

    [Header("?? 각 말풍선 표시 시간")]
    public float displayInterval = 5.0f;



    private Coroutine dialogueCoroutine;
    public UnityEvent eventFinish;
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

        // 말풍선 표시가 끝난 뒤 스테이지 변경
        eventFinish.Invoke();

    }
}
