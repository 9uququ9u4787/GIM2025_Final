using UnityEngine;
using UnityEngine.AI;

public class MainNPCController : MonoBehaviour
{
    [Header("? 이동 대상")]
    [Tooltip("NPC가 이동할 목표 위치입니다.")]
    public Transform moveTarget;

    private NavMeshAgent agent;
    private Animator animator;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        if (agent == null)
        {
            Debug.LogError("? NavMeshAgent가 NPC에 없습니다!");
        }

        if (animator == null)
        {
            Debug.LogError("? Animator가 NPC에 없습니다!");
        }
    }

    void Update()
    {
        if (animator != null && agent != null)
        {
            float speed = agent.velocity.magnitude;
            animator.SetFloat("Speed", speed);
        }
    }

    /// <summary>
    /// 외부에서 호출하면 대상 위치로 NPC가 이동합니다.
    /// </summary>
    public void MoveToTarget()
    {
        if (moveTarget != null && agent != null)
        {
            agent.SetDestination(moveTarget.position);
            Debug.Log($"??? NPC가 {moveTarget.name} 위치로 이동합니다.");
        }
        else
        {
            Debug.LogWarning("?? 이동 대상이나 에이전트가 설정되지 않았습니다.");
        }
    }
}
