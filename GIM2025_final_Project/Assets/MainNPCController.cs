using UnityEngine;
using UnityEngine.AI;

public class MainNPCController : MonoBehaviour
{
    [Header("? �̵� ���")]
    [Tooltip("NPC�� �̵��� ��ǥ ��ġ�Դϴ�.")]
    public Transform moveTarget;

    private NavMeshAgent agent;
    private Animator animator;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        if (agent == null)
        {
            Debug.LogError("? NavMeshAgent�� NPC�� �����ϴ�!");
        }

        if (animator == null)
        {
            Debug.LogError("? Animator�� NPC�� �����ϴ�!");
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
    /// �ܺο��� ȣ���ϸ� ��� ��ġ�� NPC�� �̵��մϴ�.
    /// </summary>
    public void MoveToTarget()
    {
        if (moveTarget != null && agent != null)
        {
            agent.SetDestination(moveTarget.position);
            Debug.Log($"??? NPC�� {moveTarget.name} ��ġ�� �̵��մϴ�.");
        }
        else
        {
            Debug.LogWarning("?? �̵� ����̳� ������Ʈ�� �������� �ʾҽ��ϴ�.");
        }
    }
}
