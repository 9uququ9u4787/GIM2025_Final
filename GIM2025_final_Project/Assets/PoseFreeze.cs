using UnityEngine;

public class PoseFreeze : MonoBehaviour
{
    public Animator animator;

    [Header("?? �ִϸ��̼� Ŭ�� �̸� (Animator�� State �̸��� ��ġ�ؾ� ��)")]
    public string animationStateName = "PoseIdle";

    [Header("? ������ų ���� (0 ~ 1 ����)")]
    [Range(0f, 1f)]
    public float normalizedTime = 0.5f; // �ִϸ��̼� �߰� ������

    void Start()
    {
        if (animator == null)
            animator = GetComponent<Animator>();

        FreezePose();
    }

    public void FreezePose()
    {
        if (animator != null && !string.IsNullOrEmpty(animationStateName))
        {
            animator.Play(animationStateName, 0, normalizedTime);
            animator.speed = 0f;

            Debug.Log($"??��? Animator '{animationStateName}'���� {normalizedTime * 100f:F0}% ��ġ�� �����߽��ϴ�.");
        }
        else
        {
            Debug.LogWarning("?? Animator �Ǵ� �ִϸ��̼� ���� �̸��� �������� �ʾҽ��ϴ�.");
        }
    }
}
